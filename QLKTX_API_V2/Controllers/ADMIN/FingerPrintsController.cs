using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;
using QLKTX_API_V2.Controllers.ADMIN;
using static QLKTX_API_V2.Controllers.ADMIN.FingerPrintData;

namespace QLKTX_API_V2.Controllers.QLKTX
{
    [RoutePrefix("api/FingerPrints")]
    public class FingerPrintsController : ApiController
    {
        SDKHelper SDK = new SDKHelper();
        [Route("Getdata")]
        [HttpPost] 
        public HttpResponseMessage Getdata([FromBody] filter filter)
        {
           return REST.GetHttpResponseMessFromObject( FingerPrintData.Getdata(filter));
        }
        [Route("Deletedata")]
        [HttpPost]
        public HttpResponseMessage Deletedata([FromBody]filter filter)
        {
            if (filter.startdate == null || filter.enddate == null) return null;
            HttpResponseMessage d = new HttpResponseMessage();
            string lbSysOutputInfo = "";
            int ret = SDK.sta_ConnectTCP(ref lbSysOutputInfo, filter.ip, filter.port, filter.commkey);
            if (ret == 1)
            {
                ret = SDK.sta_DeleteAttLogByPeriod(ref lbSysOutputInfo, filter.startdate, filter.enddate);
                d = REST.GetHttpResponseMessFromObject(ret == 1 ? "1" : lbSysOutputInfo);
                ret = SDK.sta_ConnectTCP(ref lbSysOutputInfo, filter.ip, filter.port, filter.commkey);
            }
            return d;
        }
        public struct datasync
        {
            public Nullable<int> type { get; set; }
            
            public KTX0050[] KTX0050 { get; set; }
        }
        [Route("Syncdata")]
        [HttpPost]
        public HttpResponseMessage Syncdata([FromBody]datasync datas)
        {
            using (DB db = new DB())
            {
                result<object> rel = new result<object>();
                if (datas.type == 1)
                {
                    datas.KTX0050.ToList().ForEach(value =>
                    {
                        var check = db.KTX0050.Where(p => p.ip == value.ip && p.sSN == value.sSN && p.User_ID == value.User_ID && p.Verify_Date == value.Verify_Date && p.Verify_Type == value.Verify_Type).FirstOrDefault();
                        if (check == null)
                        {
                            db.KTX0050.Add(value);
                        }
                    });
                    try
                    {
                        db.SaveChanges();
                        rel.set("OK", datas.KTX0050);
                    }catch(Exception f)
                    {
                        rel.set("ERR", datas.KTX0050,"Thất bại: "+f.Message);
                    }
                }

                return rel.ToHttpResponseMessage();
            }
        }
    }

    public class SDKHelper
    {
        public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();

        public List<Employee> employeeList = new List<Employee>();
        public List<BioTemplate> bioTemplateList = new List<BioTemplate>();

        public List<string> biometricTypes = new List<string>();

        private static bool bIsConnected = false;//the boolean value identifies whether the device is connected
        private static int iMachineNumber = 1;
        private static int idwErrorCode = 0;
        private static int iDeviceTpye = 1;
        bool bAddControl = true;        //Get all user's ID

        #region UserBioTypeClass

        private string _biometricType = string.Empty;
        private string _biometricVersion = string.Empty;

        private SupportBiometricType _supportBiometricType = new SupportBiometricType();

        public const string PersBioTableName = "Pers_Biotemplate";

        public const string PersBioTableFields = "*";

        public SupportBiometricType supportBiometricType
        {
            get { return _supportBiometricType; }
        }

        public string biometricType
        {
            get { return _biometricType; }
        }

        public class Employee
        {
            public string pin { get; set; }
            public string name { get; set; }
            public string password { get; set; }
            public int privilege { get; set; }
            public string cardNumber { get; set; }
        }

        public class SupportBiometricType
        {
            public bool fp_available { get; set; }
            public bool face_available { get; set; }
            public bool fingerVein_available { get; set; }
            public bool palm_available { get; set; }
        }

        public class BioTemplate
        {
            /// <summary>
            /// is valid,0:invalid,1:valid,default=1
            /// </summary>
            private int validFlag = 1;
            public virtual int valid_flag
            {
                get { return validFlag; }
                set { validFlag = value; }
            }

            /// <summary>
            /// is duress,0:not duress,1:duress,default=0
            /// </summary>
            public virtual int is_duress { get; set; }

            /// <summary>
            /// Biometric Type
            /// 0： General
            /// 1： Finger Printer
            /// 2： Face
            /// 3： Voiceprint
            /// 4： Iris
            /// 5： Retina
            /// 6： Palm prints
            /// 7： FingerVein
            /// 8： Palm Vein
            /// </summary>
            public virtual int bio_type { get; set; }

            /// <summary>
            /// template version
            /// </summary>
            public virtual string version { get; set; }

            /// <summary>
            /// data format
            /// ZK\ISO\ANSI 
            /// 0： ZK
            /// 1： ISO
            /// 2： ANSI
            /// </summary>
            public virtual int data_format { get; set; }

            /// <summary>
            /// template no
            /// </summary>
            public virtual int template_no { get; set; }

            /// <summary>
            /// template index
            /// </summary>
            public virtual int template_no_index { get; set; }

            /// <summary>
            /// template data
            /// </summary>
            public virtual string template_data { get; set; }

            /// <summary>
            /// pin
            /// </summary>
            public virtual string pin { get; set; }
        }

        public class BioType
        {
            public string name { get; set; }
            public int value { get; set; }

            public override string ToString()
            {
                return name;
            }
        }
        #endregion

        #region ConnectDevice

        public bool GetConnectState()
        {
            return bIsConnected;
        }

        public void SetConnectState(bool state)
        {
            bIsConnected = state;
            //connected = state;
        }

        public int GetMachineNumber()
        {
            return iMachineNumber;
        }

        public void SetMachineNumber(int Number)
        {
            iMachineNumber = Number;
        }

        public int sta_ConnectTCP(ref string lblOutputInfo, string ip, string port, string commKey)
        {
            if (ip == "" || port == "" || commKey == "")
            {
                lblOutputInfo=("*Name, IP, Port or Commkey cannot be null !");
                return -1;// ip or port is null
            }

            if (Convert.ToInt32(port) <= 0 || Convert.ToInt32(port) > 65535)
            {
                lblOutputInfo=("*Port illegal!");
                return -1;
            }

            if (Convert.ToInt32(commKey) < 0 || Convert.ToInt32(commKey) > 999999)
            {
                lblOutputInfo=("*CommKey illegal!");
                return -1;
            }

            int idwErrorCode = 0;

            axCZKEM1.SetCommPassword(Convert.ToInt32(commKey));

            if (bIsConnected == true)
            {
                axCZKEM1.Disconnect();
                sta_UnRegRealTime();
                SetConnectState(false);
                lblOutputInfo=("Disconnect with device !");
                //connected = false;
                return -2; //disconnect
            }

            if (axCZKEM1.Connect_Net(ip, Convert.ToInt32(port)) == true)
            {
                SetConnectState(true);
                sta_RegRealTime(ref lblOutputInfo);
                lblOutputInfo=("Connect with device !" + GetConnectState());

                //get Biotype
                sta_getBiometricType();

                return 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                lblOutputInfo=("*Unable to connect the device,ErrorCode=" + idwErrorCode.ToString());
                return idwErrorCode;
            }
        }

        public int sta_ConnectRS(ref string lblOutputInfo, string deviceid, string port, string baudrate, string commkey)
        {
            if (deviceid == "" || port == "" || baudrate == "" || commkey == "")
            {
                lblOutputInfo=("*Device ID, Port, Baudrate, Comm Key cannot be null !");
                return -1;
            }

            if (Convert.ToInt32(deviceid) < 0 || Convert.ToInt32(deviceid) > 256)
            {
                lblOutputInfo=("*Device illegal!");
                return -1;
            }

            if (Convert.ToInt32(commkey) < 0 || Convert.ToInt32(commkey) > 999999)
            {
                lblOutputInfo=("*CommKey illegal!");
                return -1;
            }

            int idwErrorCode = 0;

            int iDeviceID = Convert.ToInt32(deviceid);
            int iPort = 0;
            int iBaudrate = Convert.ToInt32(baudrate);
            int iCommkey = Convert.ToInt32(commkey);

            for (iPort = 1; iPort < 10; iPort++)
            {
                if (port.IndexOf(iPort.ToString()) > -1)
                {
                    break;
                }
            }

            axCZKEM1.SetCommPassword(iCommkey);

            if (bIsConnected == true)
            {
                axCZKEM1.Disconnect();
                sta_UnRegRealTime();
                SetConnectState(false);
                lblOutputInfo=("Disconnect with device !");
                return -2; //disconnect
            }

            if (axCZKEM1.Connect_Com(iPort, iDeviceID, iBaudrate) == true)
            {
                SetConnectState(true);
                sta_RegRealTime(ref lblOutputInfo);

                //get Biotype
                sta_getBiometricType();
                lblOutputInfo=("Connect with device !");
                return 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                lblOutputInfo=("*Unable to connect the device,ErrorCode=" + idwErrorCode.ToString());
                return idwErrorCode;
            }
        }

        public int sta_GetDeviceInfo(ref string lblOutputInfo, out string sFirmver, out string sMac, out string sPlatform, out string sSN, out string sProductTime, out string sDeviceName, out int iFPAlg, out int iFaceAlg, out string sProducter)
        {
            int iRet = 0;

            sFirmver = "";
            sMac = "";
            sPlatform = "";
            sSN = "";
            sProducter = "";
            sDeviceName = "";
            iFPAlg = 0;
            iFaceAlg = 0;
            sProductTime = "";
            string strTemp = "";

            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            axCZKEM1.EnableDevice(GetMachineNumber(), false);//disable the device

            axCZKEM1.GetSysOption(GetMachineNumber(), "~ZKFPVersion", out strTemp);
            iFPAlg = Convert.ToInt32(strTemp);

            axCZKEM1.GetSysOption(GetMachineNumber(), "ZKFaceVersion", out strTemp);
            iFaceAlg = Convert.ToInt32(strTemp);

            /*
            axCZKEM1.GetDeviceInfo(GetMachineNumber(), 72, ref iFPAlg);
            axCZKEM1.GetDeviceInfo(GetMachineNumber(), 73, ref iFaceAlg);
            */

            axCZKEM1.GetVendor(ref sProducter);
            axCZKEM1.GetProductCode(GetMachineNumber(), out sDeviceName);
            axCZKEM1.GetDeviceMAC(GetMachineNumber(), ref sMac);
            axCZKEM1.GetFirmwareVersion(GetMachineNumber(), ref sFirmver);

            /*
            if (sta_GetDeviceType() == 1)
            {
                axCZKEM1.GetDeviceFirmwareVersion(GetMachineNumber(), ref sFirmver);
            }
             */
            //lblOutputInfo=("[func GetDeviceFirmwareVersion]Temporarily unsupported");

            axCZKEM1.GetPlatform(GetMachineNumber(), ref sPlatform);
            axCZKEM1.GetSerialNumber(GetMachineNumber(), out sSN);
            axCZKEM1.GetDeviceStrInfo(GetMachineNumber(), 1, out sProductTime);

            axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device

            lblOutputInfo=("Get the device info successfully");
            iRet = 1;
            return iRet;
        }

        public int sta_GetCapacityInfo(ref string lblOutputInfo, out int adminCnt, out int userCount, out int fpCnt, out int recordCnt, out int pwdCnt, out int oplogCnt, out int faceCnt)
        {
            int ret = 0;

            adminCnt = 0;
            userCount = 0;
            fpCnt = 0;
            recordCnt = 0;
            pwdCnt = 0;
            oplogCnt = 0;
            faceCnt = 0;

            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            axCZKEM1.EnableDevice(GetMachineNumber(), false);//disable the device

            axCZKEM1.GetDeviceStatus(GetMachineNumber(), 2, ref userCount);
            axCZKEM1.GetDeviceStatus(GetMachineNumber(), 1, ref adminCnt);
            axCZKEM1.GetDeviceStatus(GetMachineNumber(), 3, ref fpCnt);
            axCZKEM1.GetDeviceStatus(GetMachineNumber(), 4, ref pwdCnt);
            axCZKEM1.GetDeviceStatus(GetMachineNumber(), 5, ref oplogCnt);
            axCZKEM1.GetDeviceStatus(GetMachineNumber(), 6, ref recordCnt);
            axCZKEM1.GetDeviceStatus(GetMachineNumber(), 21, ref faceCnt);

            axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device

            lblOutputInfo=("Get the device capacity successfully");

            ret = 1;
            return ret;
        }

        public void sta_DisConnect()
        {
            if (GetConnectState() == true)
            {
                axCZKEM1.Disconnect();
                sta_UnRegRealTime();
            }
        }

        #endregion

        #region DeviceType

        public int sta_GetDeviceType()
        {
            string sPlatform = "";
            int iFaceDevice = 0;

            if (axCZKEM1.IsTFTMachine(GetMachineNumber()))
            {
                axCZKEM1.GetDeviceInfo(GetMachineNumber(), 75, ref iFaceDevice);
                axCZKEM1.GetPlatform(GetMachineNumber(), ref sPlatform);
                if (sPlatform.Contains("ZMM"))
                {
                    return 1;//new firmware device
                }
                else if (iFaceDevice == 1)
                {
                    return 2;//face serial
                }
                else
                {
                    return 3;//color device
                }
            }
            else
            {
                return 4;//black&whith device
            }

        }

        #endregion

        #region RealTimeEvent

        public void sta_UnRegRealTime()
        {

        }

        public int sta_RegRealTime(ref string lblOutputInfo)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            int ret = 0;

            if (axCZKEM1.RegEvent(GetMachineNumber(), 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            {
                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*RegEvent failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("*No data from terminal returns!");
                }
            }
            return ret;
        }

        #endregion

        #region UserMng

        #region UserInfo

        public int sta_GetHIDEventCardNum(ref string lblOutputInfo)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            int idwErrorCode = 0;
            string strHIDEventCardNum = "";

            if (axCZKEM1.GetHIDEventCardNumAsStr(out strHIDEventCardNum))
            {
                lblOutputInfo=("GetHIDEventCardNumAsStr! HIDCardNum=" + strHIDEventCardNum);
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                lblOutputInfo=("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            }

            return 1;
        }

        #endregion

        public int sta_uploadOneUserPhoto(ref string lblOutputInfo, string fullName)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            int ret = 0;

            axCZKEM1.EnableDevice(iMachineNumber, false);

            if (axCZKEM1.UploadUserPhoto(GetMachineNumber(), fullName))
            {
                axCZKEM1.RefreshData(GetMachineNumber());//the data in the device should be refreshed
                ret = 1;
                lblOutputInfo=("Upload User Photo To the Device succeed!");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*Upload user photo failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
            }

            //lblOutputInfo=("[func UploadUserPhoto]Temporarily unsupported");
            lblOutputInfo=(fullName);
            if (axCZKEM1.SendFile(GetMachineNumber(), fullName))
            {
                axCZKEM1.RefreshData(GetMachineNumber());//the data in the device should be refreshed
                ret = 1;
                lblOutputInfo=("Upload User Photo To the Device succeed!");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*Upload user photo failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
            }
            axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device

            return ret;
        }

        public int sta_downloadOneUserPhoto(ref string lblOutputInfo, string userID, string path)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            if (path == "")
            {
                lblOutputInfo=("*Select photo path first.");
                return -1023;
            }

            if (userID == "")
            {
                lblOutputInfo=("*Input User ID first.");
                return -1022;
            }

            int ret = 0;
            string photoName = userID + ".jpg";

            axCZKEM1.EnableDevice(iMachineNumber, false);

            if (axCZKEM1.DownloadUserPhoto(GetMachineNumber(), photoName, path))
            {
                ret = 1;
                lblOutputInfo=("Download User Photo from the Device succeed!");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("Download user photo failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
            }

            //lblOutputInfo=("[func DownloadUserPhoto]Temporarily unsupported");
            axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device

            return ret;
        }

        public int sta_DeleteOneUserPhoto(ref string lblOutputInfo, string userID)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            if (userID == "")
            {
                lblOutputInfo=("*Input User ID first.");
                return -1022;
            }

            int ret = 0;
            string photoName = userID + ".jpg";

            axCZKEM1.EnableDevice(iMachineNumber, false);

            if (axCZKEM1.DeleteUserPhoto(GetMachineNumber(), photoName))
            {
                axCZKEM1.RefreshData(GetMachineNumber());//the data in the device should be refreshed
                ret = 1;
                lblOutputInfo=("Delate User Photo in the Device succeed!");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*Delete user photo failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
            }

            //lblOutputInfo=("[func DeleteUserPhoto]Temporarily unsupported");
            axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device

            return ret;
        }

        public int sta_ClearSMS(ref string lblOutputInfo)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            int idwErrorCode = 0;

            axCZKEM1.EnableDevice(iMachineNumber, false);
            if (axCZKEM1.ClearSMS(iMachineNumber))
            {
                axCZKEM1.RefreshData(iMachineNumber);//After you have set user short message,you should refresh the data of the device
                lblOutputInfo=("Successfully clear all the SMS! ");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                lblOutputInfo=("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            }
            axCZKEM1.EnableDevice(iMachineNumber, true);

            return 1;
        }

        public int sta_ClearUserSMS(ref string lblOutputInfo)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            int idwErrorCode = 0;

            axCZKEM1.EnableDevice(iMachineNumber, false);
            if (axCZKEM1.ClearUserSMS(iMachineNumber))
            {
                axCZKEM1.RefreshData(iMachineNumber);//After you have set user short message,you should refresh the data of the device
                lblOutputInfo=("Successfully clear all the user SMS! ");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                lblOutputInfo=("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            }
            axCZKEM1.EnableDevice(iMachineNumber, true);

            return 1;
        }
        #endregion

        public int sta_ClearWorkCode(ref string lblOutputInfo)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            int idwErrorCode = 0;

            axCZKEM1.EnableDevice(iMachineNumber, false);
            if (axCZKEM1.SSR_ClearWorkCode())
            {
                lblOutputInfo=("Successfully clear all workcode");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                lblOutputInfo=("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            }

            axCZKEM1.EnableDevice(iMachineNumber, true);

            return 1;
        }
     

        #region user role

        public string[] sApp = new string[]
        {
            "usermng",
            "access",
            "iccardmng",
            "comset",
            "sysset",
            "myset",
            "datamng",
            "udiskmng",
            "logquery",
            "printset",
            "sms",
            "workcode",
            "autotest",
            "sysinfo"
        };

        public string[] sFunUserMng = new string[]
        {
            "adduser",
            "userlist",
            "userliststyle"
        };

        public string[] sFunAccess = new string[]
        {
            "timezone",
            "holiday",
            "group",
            "unlockcomb",
            "accparam",
            "duressalarm",
            "antipassbackset"
        };

        public string[] sFunICCard = new string[]
        {
            "enrollnumcard",
            "enrollfpcard",
            "clearcard",
            "copycard",
            "setcardparam"
        };

        public string[] sFunComm = new string[]
        {
            "netset",
            "serialset",
            "linkset",
            "mobilenet",
            "wifiset",
            "admsset",
            "wiegandset"
        };

        public string[] sFunSystem = new string[]
        {
            "timeset",
            "attparam",
            "fpparam",
            "restoreset",
            "udiskupgrade",
        };

        public string[] sFunPersonalize = new string[]
        {
            "displayset",
            "voiceset",
            "bellset",
            "shortcutsset",
            "statemodeset",
            "autopowerset"
        };

        public string[] sFunDataMng = new string[]
        {
            "cleardata",
            "backupdata",
            "restoredata"
        };

        public string[] sFunUSBMng = new string[]
        {
            "udiskupload",
            "udiskdownload",
            "udiskset"
        };

        public string[] sFunAttSearch = new string[]
        {
            "attlog",
            "attpic",
            "blacklistpic"
        };

        public string[] sFunPrint = new string[]
        {
            "printinfoset",
            "printfuncset"
        };

        public string[] sFunSMS = new string[]
        {
            "addsms",
            "smslist"
        };

        public string[] sFunWorkCode = new string[]
        {
            "addworkcode",
            "workcodelist",
            "workcodesetting"
        };

        public string[] sFunAutoTest = new string[]
        {
            "alltest",
            "screentest",
            "voicetest",
            "keytest",
            "fptest",
            "realtimetest",
            "cameratest"
        };

        public string[] sFunSysInfo = new string[]
        {
            "datacapacity",
            "devinfo",
            "firmwareinfo"
        };

        private string sta_getSysOptions(string option)
        {
            string value = string.Empty;
            axCZKEM1.GetSysOption(iMachineNumber, option, out value);
            return value;
        }

        /// <summary>
        /// get version
        /// </summary>
        /// <returns></returns>
        public void sta_getBiometricVersion()
        {
            string result = string.Empty;
            _biometricVersion = sta_getSysOptions("BiometricVersion");
        }

        /// <summary>
        /// get support type
        /// </summary>
        /// <returns></returns>
        public void sta_getBiometricType()
        {
            string result = string.Empty;
            result = sta_getSysOptions("BiometricType");
            if (!string.IsNullOrEmpty(result))
            {
                _supportBiometricType.fp_available = result[1] == '1';
                _supportBiometricType.face_available = result[2] == '1';
                if (result.Length >= 9)
                {
                    _supportBiometricType.fingerVein_available = result[7] == '1';
                    _supportBiometricType.palm_available = result[8] == '1';
                }
            }
            _biometricType = result;
        }

        public List<Employee> sta_getEmployees()
        {
            if (!GetConnectState())
            {
                return new List<Employee>();
            }
            List<Employee> employees = new List<Employee>();

            string empnoStr = string.Empty;
            string name = string.Empty;
            string pwd = string.Empty;
            int pri = 0;
            bool enable = true;
            string cardNum = string.Empty;

            axCZKEM1.EnableDevice(iMachineNumber, false);
            try
            {
                axCZKEM1.ReadAllUserID(iMachineNumber);

                while (axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, out empnoStr, out name, out pwd, out pri, out enable))
                {
                    cardNum = "";
                    if (axCZKEM1.GetStrCardNumber(out cardNum))
                    {
                        if (string.IsNullOrEmpty(cardNum))
                            cardNum = "";
                    }
                    if (!string.IsNullOrEmpty(name))
                    {
                        int index = name.IndexOf("\0");
                        if (index > 0)
                        {
                            name = name.Substring(0, index);
                        }
                    }

                    Employee emp = new Employee();
                    emp.pin = empnoStr;
                    emp.name = name;
                    emp.privilege = pri;
                    emp.password = pwd;
                    emp.cardNumber = cardNum;

                    employees.Add(emp);
                }
            }
            catch
            {

            }
            finally
            {
                axCZKEM1.EnableDevice(iMachineNumber, true);
            }
            return employees;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="bioTemplate"></param>
        private void sta_getBioTemplateFromBuffer(string buffer, ref BioTemplate bioTemplate)
        {
            string temp;
            for (int i = 1; i <= 10; i++)
            {
                if (buffer.IndexOf(',') > 0)
                {
                    temp = buffer.Substring(0, buffer.IndexOf(','));
                }
                else
                {
                    temp = buffer;
                }

                switch (i)
                {
                    case 1:
                        bioTemplate.pin = temp;
                        break;
                    case 2:
                        bioTemplate.valid_flag = int.Parse(temp);
                        break;
                    case 3:
                        bioTemplate.is_duress = int.Parse(temp);
                        break;
                    case 4:
                        bioTemplate.bio_type = int.Parse(temp);
                        break;
                    case 5:
                        bioTemplate.version = temp;
                        break;
                    case 6:
                        bioTemplate.version = bioTemplate.version + "." + temp;
                        break;
                    case 7:
                        bioTemplate.data_format = int.Parse(temp);
                        break;
                    case 8:
                        bioTemplate.template_no = int.Parse(temp);
                        break;
                    case 9:
                        bioTemplate.template_no_index = int.Parse(temp);
                        break;
                    case 10:
                        bioTemplate.template_data = temp;
                        break;
                }

                buffer = buffer.Substring(buffer.IndexOf(',') + 1);
            }
        }

        public void sta_setEmployees(List<Employee> employees)
        {
            axCZKEM1.EnableDevice(1, false);
            try
            {
                bool batchUpdate = axCZKEM1.BeginBatchUpdate(iMachineNumber, 1);
                foreach (Employee emp in employees)
                {
                    axCZKEM1.SetStrCardNumber(emp.cardNumber);
                    axCZKEM1.SSR_SetUserInfo(iMachineNumber, emp.pin, emp.name, emp.password, emp.privilege, true);
                }
                if (batchUpdate)
                {
                    axCZKEM1.BatchUpdate(iMachineNumber);
                    batchUpdate = false;
                }
            }
            catch
            { }
            finally
            {
                axCZKEM1.EnableDevice(iMachineNumber, true);
            }
        }

        #endregion


        #region PersonalizeMng
        public int sta_GetAllBellData(ref string lblOutputInfo, DataTable dt_allBell)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            int ret = 0;
            axCZKEM1.EnableDevice(GetMachineNumber(), false);//disable the device

            int weekDay;
            int Index;
            int Enable;
            int Hour;
            int min;
            int voice;
            int way;
            int inerbelldelay;
            int extbelldelay;

            if (axCZKEM1.ReadAllBellSchData(GetMachineNumber()))//read all the bell schedual data records to the memory
            {
                while (axCZKEM1.GetEachBellInfo(GetMachineNumber(), out weekDay, out Index, out Enable, out Hour, out min, out voice, out way, out inerbelldelay, out extbelldelay))
                {
                    DataRow dr = dt_allBell.NewRow();
                    dr["ID"] = Index;
                    dr["Enable"] = Enable;
                    dr["Time"] = Hour + ":" + min;
                    dr["WaveIndex"] = voice;
                    dr["BellType"] = way;
                    if (way == 0)
                    {
                        dr["InerDelay"] = inerbelldelay;
                        dr["ExtDelay"] = 0;
                    }
                    else if (way == 1)
                    {
                        dr["InerDelay"] = 0;
                        dr["ExtDelay"] = extbelldelay;
                    }
                    else
                    {
                        dr["InerDelay"] = inerbelldelay;
                        dr["ExtDelay"] = extbelldelay;
                    }

                    dr["Mon"] = (weekDay & (1 << 0)) > 0 ? 1 : 0;
                    dr["Tue"] = (weekDay & (1 << 1)) > 0 ? 1 : 0;
                    dr["Wed"] = (weekDay & (1 << 2)) > 0 ? 1 : 0;
                    dr["Thu"] = (weekDay & (1 << 3)) > 0 ? 1 : 0;
                    dr["Fri"] = (weekDay & (1 << 4)) > 0 ? 1 : 0;
                    dr["Sat"] = (weekDay & (1 << 5)) > 0 ? 1 : 0;
                    dr["Sun"] = (weekDay & (1 << 6)) > 0 ? 1 : 0;
                    dt_allBell.Rows.Add(dr);
                }
                ret = 1;
                lblOutputInfo=("Get bell successfully");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*Read all bell schedual data failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
            }
            axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device
            return ret;
        }

        public int sta_setBellInfo(ref string lblOutputInfo, int weekday, int index, int Enable, int Hour, int min, int voice, int bellway, int inerbelldelay, int extbelldelay)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            int iCurBellCount, tmpWeekday = 0, tmpEnable = 0, tmpHour = 0, tmpMin = 0, tmpVoice = 0, tmpBellway = 0, tmpInerbelldelay = 0, tmpExtbelldelay = 0;

            if (axCZKEM1.GetBellSchDataEx(GetMachineNumber(), tmpWeekday, index, out tmpEnable, out tmpHour, out tmpMin, out tmpVoice, out tmpBellway, out tmpInerbelldelay, out tmpExtbelldelay) == false)
            {
                axCZKEM1.GetDayBellSchCount(GetMachineNumber(), out iCurBellCount);
                if (iCurBellCount >= 64)
                {
                    lblOutputInfo=("*The bell count is 64!!!");
                    return -1023;
                }
            }

            int iIsSupportExAlarm = 0;

            axCZKEM1.GetDeviceInfo(GetMachineNumber(), 79, ref iIsSupportExAlarm);

            if (iIsSupportExAlarm <= 0 && (bellway == 1 || bellway == 2))
            {
                lblOutputInfo=("*The Device does not support external bell!");
                return -1022;
            }

            int ret = 0;
            axCZKEM1.EnableDevice(GetMachineNumber(), false);//disable the device


            if (axCZKEM1.SetBellSchDataEx(GetMachineNumber(), weekday, index, Enable, Hour, min, voice, bellway, inerbelldelay, extbelldelay))
            {
                axCZKEM1.RefreshData(GetMachineNumber());
                ret = 1;
                lblOutputInfo=("Set Bell Schedule successfully!");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*Set bell info failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
            }

            axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device
            return ret;
        }

        public int sta_getShortkeyByID(ref string lblOutputInfo, int ShortKeyID, ref string ShortKeyName, ref string FunctionName, ref int ShortKeyFun, ref int stateCode, ref string stateName, ref string description, ref int intAutoChange, ref string strAutoChangeTime)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            int ret = 0;
            axCZKEM1.EnableDevice(GetMachineNumber(), false);//disable the device

            if (axCZKEM1.GetShortkey(GetMachineNumber(), ShortKeyID, ref ShortKeyName, ref FunctionName, ref ShortKeyFun, ref stateCode, ref stateName, ref description, ref intAutoChange, ref strAutoChangeTime))
            {
                lblOutputInfo=("Get shortkey successfully. Name:" + ShortKeyName + ",FunctionName:" + FunctionName);
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*GetShortkeyByID failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    ret = -1;
                    lblOutputInfo=("No data from terminal returns!");
                }
            }

            axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device
            return ret;
        }

        public int sta_setShortkey(ref string lblOutputInfo, int ShortKeyID, string ShortKeyName, string FunctionName, int ShortKeyFun, int stateCode, string stateName, string description, int intAutoChange, string strAutoChangeTime)
        {

            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            int ret = 0;
            axCZKEM1.EnableDevice(GetMachineNumber(), false);//disable the device

            if (axCZKEM1.SetShortkey(GetMachineNumber(), ShortKeyID, ShortKeyName, FunctionName, ShortKeyFun, stateCode, stateName, description, intAutoChange, strAutoChangeTime))
            {
                lblOutputInfo=("Set shortkey successfully. Name:" + ShortKeyName + ",FunctionName:" + FunctionName);
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*SetShortkey failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
            }


            axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device
            return ret;
        }


        public int sta_uploadAdvertisePicture(ref string lblOutputInfo, string pictureFile, string pictureName)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            int ret = 0;
            axCZKEM1.EnableDevice(GetMachineNumber(), false);//disable the device

            if (axCZKEM1.UploadPicture(GetMachineNumber(), pictureFile, pictureName))
            {
                ret = 1;
                lblOutputInfo=("Update a advertise picture!");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*Upload advertise picture failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
            }

            axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device
            return ret;
        }

        public int sta_uploadWallpaper(ref string lblOutputInfo, string pictureFile, string pictureName)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            int ret = 0;
            axCZKEM1.EnableDevice(GetMachineNumber(), false);//disable the device

            if (axCZKEM1.UploadTheme(GetMachineNumber(), pictureFile, pictureName))
            {
                ret = 1;
                lblOutputInfo=("Update a wallpaper!");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*Upload wallpaper failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
            }

            axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device
            return ret;
        }

        #endregion

        #region DataMng

        #region  AttLogMng

        public int sta_readAttLog(ref string lblOutputInfo, DataTable dt_log)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            int ret = 0;

            axCZKEM1.EnableDevice(GetMachineNumber(), false);//disable the device

            string sdwEnrollNumber = "";
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkcode = 0;

            if (axCZKEM1.ReadGeneralLogData(GetMachineNumber()))
            {
                int i = 1;
                while (axCZKEM1.SSR_GetGeneralLogData(GetMachineNumber(), out sdwEnrollNumber, out idwVerifyMode,
                            out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                {
                    DataRow dr = dt_log.NewRow();
                    dr["STT"] = i++;
                    dr["User ID"] = sdwEnrollNumber;
                    dr["Verify Date"] = idwYear + "-" + idwMonth + "-" + idwDay + " " + idwHour + ":" + idwMinute + ":" + idwSecond;
                    dr["Verify Type"] = idwVerifyMode;
                    dr["Verify State"] = idwInOutMode;
                    dr["WorkCode"] = idwWorkcode;
                    dt_log.Rows.Add(dr);
                }
                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*Read attlog failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
            }

            axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device

            return ret;
        }

        public int sta_readLogByPeriod(ref string lblOutputInfo,ref DataTable dt_logPeriod, string fromTime, string toTime,string ip, List<KTX0050> list=null )
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            int ret = 0;

            axCZKEM1.EnableDevice(GetMachineNumber(), false);//disable the device

            string sdwEnrollNumber = "";
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkcode = 0;


            if (axCZKEM1.ReadTimeGLogData(GetMachineNumber(), fromTime, toTime))
            {//ref string lblOutputInfo, out string sFirmver, out string sMac, out string sPlatform, out string sSN, out string sProductTime,
                //out string sDeviceName, out int iFPAlg, out int iFaceAlg, out string sProducter
               // string lblOutputInfo;
                string sFirmver;
                string sMac;
                string sPlatform;
                string sSN;
                string sProductTime;
                string sDeviceName;
                int iFPAlg;
                int iFaceAlg;
                string sProducter;
                sta_GetDeviceInfo(ref lblOutputInfo, out sFirmver, out sMac, out sPlatform, out sSN, out sProductTime,
                out sDeviceName, out iFPAlg, out iFaceAlg, out sProducter);
                int i = 1;
                while (axCZKEM1.SSR_GetGeneralLogData(GetMachineNumber(), out sdwEnrollNumber, out idwVerifyMode,
                            out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                {
                    if (list == null)
                    {
                        DataRow dr = dt_logPeriod.NewRow();
                        dr["STT"] = i++;
                        dr["User_ID"] = sdwEnrollNumber;
                        dr["Verify_Date"] = idwYear + "-" + idwMonth + "-" + idwDay + " " + idwHour + ":" + idwMinute + ":" + idwSecond;
                        dr["Verify_Type"] = idwVerifyMode;
                        dr["Verify_State"] = idwInOutMode;
                        dr["WorkCode"] = idwWorkcode;
                        dr["sDeviceName"] = sDeviceName;
                        dr["sSN"] = sSN;
                        dr["ip"] = ip;
                        dt_logPeriod.Rows.Add(dr);
                    }
                    else
                    {
                        list.Add(new KTX0050()
                        {
                            ip=ip,
                            sSN=sSN,
                            User_ID=sdwEnrollNumber,
                            Verify_Date=DateTime.Parse( idwYear + "-" + idwMonth + "-" + idwDay + " " + idwHour + ":" + idwMinute + ":" + idwSecond),
                            Verify_State=idwInOutMode,
                            Verify_Type=idwVerifyMode,
                            WorkCode=idwWorkcode,
                        });
                    }
                }
                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*Read attlog by period failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
            }


            //lblOutputInfo=("[func ReadTimeGLogData]Temporarily unsupported");
            axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device

            return ret;
        }

        public int sta_DeleteAttLog(ref string lblOutputInfo)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            int ret = 0;

            axCZKEM1.EnableDevice(GetMachineNumber(), false);//disable the device


            if (axCZKEM1.ClearGLog(GetMachineNumber()))
            {
                axCZKEM1.RefreshData(GetMachineNumber());
                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*Delete attlog, ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
            }

            axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device

            return ret;
        }

        public int sta_DeleteAttLogByPeriod(ref string lblOutputInfo, string fromTime, string toTime)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            int ret = 0;

            axCZKEM1.EnableDevice(GetMachineNumber(), false);//disable the device


            if (axCZKEM1.DeleteAttlogBetweenTheDate(GetMachineNumber(), fromTime, toTime))
            {
                axCZKEM1.RefreshData(GetMachineNumber());
                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*Delete attlog by period failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
            }

            //lblOutputInfo=("[func DeleteAttlogBetweenTheDate]Temporarily unsupported");
            axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device

            return ret;
        }

        public int sta_DelOldAttLogFromTime(ref string lblOutputInfo, string fromTime)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("Please connect first!");
                return -1024;
            }

            int ret = 0;

            axCZKEM1.EnableDevice(GetMachineNumber(), false);//disable the device


            if (axCZKEM1.DeleteAttlogByTime(GetMachineNumber(), fromTime))
            {
                axCZKEM1.RefreshData(GetMachineNumber());
                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*Delete old attlog from time failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
            }

            //lblOutputInfo=("[func DeleteAttlogByTime]Temporarily unsupported");
            axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device

            return ret;
        }

        public int sta_ReadNewAttLog(ref string lblOutputInfo, DataTable dt_logNew)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("Please connect first!");
                return -1024;
            }

            int ret = 0;

            axCZKEM1.EnableDevice(GetMachineNumber(), false);//disable the device

            string sdwEnrollNumber = "";
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkcode = 0;


            if (axCZKEM1.ReadNewGLogData(GetMachineNumber()))
            {
                while (axCZKEM1.SSR_GetGeneralLogData(GetMachineNumber(), out sdwEnrollNumber, out idwVerifyMode,
                            out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                {
                    DataRow dr = dt_logNew.NewRow();
                    dr["User ID"] = sdwEnrollNumber;
                    dr["Verify Date"] = idwYear + "-" + idwMonth + "-" + idwDay + " " + idwHour + ":" + idwMinute + ":" + idwSecond;
                    dr["Verify Type"] = idwVerifyMode;
                    dr["Verify State"] = idwInOutMode;
                    dr["WorkCode"] = idwWorkcode;
                    dt_logNew.Rows.Add(dr);
                }
                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*Read attlog by period failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
            }

            //lblOutputInfo=("[func ReadNewGLogData]Temporarily unsupported");
            axCZKEM1.EnableDevice(GetMachineNumber(), true);//enable the device

            return ret;
        }
        #endregion

        #region OPLOG
        public int sta_GetOplog(ref string lblOutputInfo, DataTable dt_Oplog)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }
            int ret = 0;
            int iSuperLogCount = 0;

            axCZKEM1.EnableDevice(GetMachineNumber(), false);

            //if (axCZKEM1.ReadSuperLogData(GetMachineNumber()))
            if (axCZKEM1.ReadAllSLogData(GetMachineNumber()))
            {
                int idwTMachineNumber = 0;
                int iParams1 = 0;
                int iParams2 = 0;
                int idwManipulation = 0;
                int iParams3 = 0;

                int iParams4 = 0;
                int iYear = 0;
                int iMonth = 0;
                int iDay = 0;
                int iHour = 0;
                int iMin = 0;
                int iSencond = 0;
                int iAdmin = 0;

                string sUser = null;
                string sAdmin = null;
                string sTime = null;

                //while (axCZKEM1.SSR_GetSuperLogData(GetMachineNumber(), out idwTMachineNumber, out sAdmin, out sUser,
                //    out idwManipulation, out sTime, out iParams1, out iParams2, out iParams3))
                while (axCZKEM1.GetSuperLogData2(GetMachineNumber(), ref idwTMachineNumber, ref iAdmin, ref iParams4, ref iParams1, ref iParams2, ref idwManipulation, ref iParams3, ref iYear, ref iMonth, ref iDay, ref iHour, ref iMin, ref iSencond))
                {
                    iSuperLogCount++;
                    DataRow dr = dt_Oplog.NewRow();
                    dr["Count"] = iSuperLogCount;
                    dr["MachineNumber"] = GetMachineNumber();
                    dr["Admin"] = iAdmin;
                    //dr["UserPIN2"] = sUser;
                    dr["Operation"] = idwManipulation;
                    sTime = iYear + "-" + iMonth + "-" + iDay + " " + iHour + ":" + iMin + ":" + iSencond;
                    dr["DateTime"] = sTime;
                    dr["Param1"] = iParams1;
                    dr["Param2"] = iParams2;
                    dr["Param3"] = iParams3;
                    dr["Param4"] = iParams4;
                    dt_Oplog.Rows.Add(dr);
                }

                lblOutputInfo=("Down oplog success.");
                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                ret = idwErrorCode;

                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*Get OPLOG failed,ErrorCode: " + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
            }

            axCZKEM1.EnableDevice(GetMachineNumber(), true);

            return ret;
        }

        public int sta_ClearOplog(ref string lblOutputInfo)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }
            int ret = 0;

            axCZKEM1.EnableDevice(GetMachineNumber(), false);

            if (axCZKEM1.ClearSLog(GetMachineNumber()))
            {
                axCZKEM1.RefreshData(GetMachineNumber());//the data in the device should be refreshed
                lblOutputInfo=("All operation logs have been cleared from teiminal!");
                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("ClearOplog failed,ErrorCode=" + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
                ret = idwErrorCode;
            }

            axCZKEM1.EnableDevice(GetMachineNumber(), true);
            return ret;
        }
        #endregion

        #region ClearData
        public int sta_ClearAdmin(ref string lblOutputInfo)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }
            int ret = 0;

            axCZKEM1.EnableDevice(GetMachineNumber(), false);

            if (axCZKEM1.ClearAdministrators(GetMachineNumber()))
            {
                axCZKEM1.RefreshData(GetMachineNumber());//the data in the device should be refreshed
                lblOutputInfo=("All administrator have been cleared from teiminal!");
                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*ClearAdmin failed,ErrorCode=" + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
                ret = idwErrorCode;
            }

            axCZKEM1.EnableDevice(GetMachineNumber(), true);
            return ret;
        }

        public int sta_ClearAllLogs(ref string lblOutputInfo)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }
            int ret = 0;

            axCZKEM1.EnableDevice(GetMachineNumber(), false);

            if (axCZKEM1.ClearData(GetMachineNumber(), 1))
            {
                axCZKEM1.RefreshData(GetMachineNumber());//the data in the device should be refreshed
                lblOutputInfo=("All AttLogs have been cleared from teiminal!");
                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*ClearAllLogs failed,ErrorCode=" + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
                ret = idwErrorCode;
            }

            axCZKEM1.EnableDevice(GetMachineNumber(), true);
            return ret;
        }

        public int sta_ClearAllFps(ref string lblOutputInfo)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }
            int ret = 0;

            axCZKEM1.EnableDevice(GetMachineNumber(), false);

            if (axCZKEM1.ClearData(GetMachineNumber(), 2))
            {
                axCZKEM1.RefreshData(GetMachineNumber());//the data in the device should be refreshed
                lblOutputInfo=("All fp templates have been cleared from teiminal!");
                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*ClearAllFps failed,ErrorCode=" + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
                ret = idwErrorCode;
            }

            axCZKEM1.EnableDevice(GetMachineNumber(), true);
            return ret;
        }

        public int sta_ClearAllUsers(ref string lblOutputInfo)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }
            int ret = 0;

            axCZKEM1.EnableDevice(GetMachineNumber(), false);

            if (axCZKEM1.ClearData(GetMachineNumber(), 5))
            {
                axCZKEM1.RefreshData(GetMachineNumber());//the data in the device should be refreshed
                lblOutputInfo=("All users have been cleared from teiminal!");
                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*ClearAllUsers failed,ErrorCode=" + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
                ret = idwErrorCode;
            }

            axCZKEM1.EnableDevice(GetMachineNumber(), true);
            return ret;
        }

        public int sta_ClearAllData(ref string lblOutputInfo)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }
            int ret = 0;

            axCZKEM1.EnableDevice(GetMachineNumber(), false);

            if (axCZKEM1.ClearKeeperData(GetMachineNumber()))
            {
                axCZKEM1.RefreshData(GetMachineNumber());//the data in the device should be refreshed
                lblOutputInfo=("All Data have been cleared from teiminal!");
                ret = 1;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                if (idwErrorCode != 0)
                {
                    lblOutputInfo=("*ClearAllData failed,ErrorCode=" + idwErrorCode.ToString());
                }
                else
                {
                    lblOutputInfo=("No data from terminal returns!");
                }
                ret = idwErrorCode;
            }

            axCZKEM1.EnableDevice(GetMachineNumber(), true);
            return ret;
        }
        #endregion


        public int sta_CloseAlarm(ref string lblOutputInfo)
        {
            /*
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect the device first!");
                return -1024;
            }
            int idwErrorCode = 0;

            if(axCZKEM1.CloseAlarm(iMachineNumber))
            {
                lblOutputInfo=("Close alarm successful");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                lblOutputInfo=("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
                return idwErrorCode;
            }
             * */
            lblOutputInfo=("[func CloseAlarm]Temporarily unsupported");
            return 1;
        }
        #endregion


        #region control

        public int sta_btnRestartDevice(ref string lblOutputInfo)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }



            if (axCZKEM1.RestartDevice(iMachineNumber))
            {
                sta_DisConnect();
                lblOutputInfo=("The device will restart");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                lblOutputInfo=("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            }

            return 1;
        }

        public int sta_btnPowerOffDevice(ref string lblOutputInfo)
        {
            if (GetConnectState() == false)
            {
                lblOutputInfo=("*Please connect first!");
                return -1024;
            }

            if (axCZKEM1.PowerOffDevice(iMachineNumber))
            {
                sta_DisConnect();
                lblOutputInfo=("Power off device");
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                lblOutputInfo=("*Operation failed,ErrorCode=" + idwErrorCode.ToString());
            }

            return 1;
        }

        #endregion

    }
}
