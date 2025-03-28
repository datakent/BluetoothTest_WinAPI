﻿using System;
using System.Globalization;
using System.Runtime.InteropServices;
using Utils;

namespace Bluetooth_WinAPI
{
    class Program
    {
        static void Main(string[] args)
        {   
            //"Bluetooth View" uygulaması ile cihaz mac adresi alınabilir.
            string deviceMacAddress = "00:00:0e:03:40:0f";

            string fileName = "TestBitmap.bmp";
            
            var p = new TSPLCmd();
            p.addCmd("SIZE 80 mm,40 mm");
            p.addCmd("GAP 0 mm,0 mm"); //0,0 -> Continuous label
            p.addCmd("DIRECTION 0");
            p.addCmd("CLS");           //This command must be placed after SIZE command
            p.addCmdImgFromFile(50, 20, fileName);
            //p.addCmdImg(50, 20, 13, 100, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0x07, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x0F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 0x3F, 0xFF, 0xC0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x83, 0xFF, 0xFF, 0xFC, 0x1F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0x1F, 0xFE, 0x6F, 0xFF, 0x87, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF8, 0xFF, 0xFE, 0x4D, 0xBF, 0xF1, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xE3, 0xFF, 0xCF, 0x0C, 0xBF, 0xFC, 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xCF, 0xFB, 0xD6, 0x0E, 0xAB, 0xFF, 0x1F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x3F, 0xFC, 0xCE, 0xB8, 0xAA, 0xBF, 0xCF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0x7F, 0x1E, 0xEF, 0xFF, 0xF9, 0x1F, 0xE7, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF8, 0xFD, 0x7F, 0xFF, 0xFF, 0xFB, 0x5E, 0x79, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF3, 0xF1, 0x9F, 0xFF, 0xFF, 0xF7, 0x1D, 0xBC, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xE7, 0xD2, 0xFF, 0xFF, 0xFF, 0xFF, 0xF8, 0xBE, 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xCF, 0xEB, 0xFF, 0xFF, 0xFF, 0xFF, 0xFB, 0x7F, 0x3F, 0xFF, 0xFF, 0xFF, 0xFF, 0x9F, 0x37, 0xFF, 0xFF, 0xFF, 0xFF, 0xFC, 0x6F, 0x9F, 0xFF, 0xFF, 0xFF, 0xFF, 0x3F, 0x37, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xA7, 0xCF, 0xFF, 0xFF, 0xFF, 0xFE, 0x7D, 0x9F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x8D, 0xE7, 0xFF, 0xFF, 0xFF, 0xFC, 0xF8, 0xBF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xD9, 0xF3, 0xFF, 0xFF, 0xFF, 0xFD, 0xDE, 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF1, 0xF9, 0xFF, 0xFF, 0xFF, 0xFB, 0xE4, 0xFF, 0xFF, 0xF0, 0x00, 0x00, 0x3F, 0xFB, 0xFD, 0xFF, 0xFF, 0xFF, 0xF3, 0x63, 0xFF, 0xFF, 0xE0, 0x00, 0x00, 0xFF, 0xFE, 0x3C, 0xFF, 0xFF, 0xFF, 0xE7, 0x9B, 0xFF, 0xFF, 0x80, 0x00, 0x01, 0xFF, 0xFC, 0xBE, 0x7F, 0xFF, 0xFF, 0xEF, 0xCF, 0xFF, 0xFF, 0x00, 0x00, 0x07, 0xFF, 0xFE, 0x7F, 0x7F, 0xFF, 0xFF, 0xCF, 0xEF, 0xFF, 0xFE, 0x00, 0x00, 0x0F, 0xFF, 0xFF, 0xCF, 0x3F, 0xFF, 0xFF, 0xDF, 0xFF, 0xFF, 0xFC, 0x00, 0x00, 0x3F, 0xFF, 0xFF, 0xB7, 0xBF, 0xFF, 0xFF, 0x9F, 0xFF, 0xFF, 0xF8, 0x00, 0x00, 0x7F, 0xFF, 0xFF, 0xEF, 0xDF, 0xFF, 0xFF, 0xBB, 0xBF, 0xFF, 0xF0, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xD9, 0xCF, 0xFF, 0xFF, 0x37, 0x7F, 0xFF, 0xF0, 0x00, 0x01, 0xFF, 0xFF, 0xFF, 0xE7, 0xEF, 0xFF, 0xFF, 0x77, 0x7F, 0xFF, 0xE0, 0x00, 0x03, 0xFE, 0x1F, 0xFF, 0xF9, 0xEF, 0xFF, 0xFE, 0x72, 0x7F, 0xFF, 0xC0, 0x00, 0x07, 0xFC, 0x0F, 0xFF, 0xF7, 0xE7, 0xFF, 0xFE, 0xF8, 0xFF, 0xFF, 0xC0, 0x00, 0x0F, 0xF8, 0x0F, 0xFF, 0xFD, 0xF7, 0xFF, 0xFE, 0xFF, 0xFF, 0xFF, 0x80, 0x00, 0x1F, 0xF8, 0x07, 0xFF, 0xF2, 0x73, 0xFF, 0xFC, 0xDD, 0xFF, 0xFF, 0x00, 0x00, 0x3F, 0xF0, 0x07, 0xFF, 0xE6, 0xFB, 0xFF, 0xFD, 0xC7, 0xFF, 0xFF, 0x00, 0x00, 0x3F, 0xF0, 0x07, 0xFF, 0xF1, 0xFB, 0xFF, 0xFD, 0xB3, 0xFF, 0xFE, 0x00, 0x00, 0x7F, 0xF0, 0x07, 0xFF, 0xFE, 0x79, 0xFF, 0xF9, 0xFF, 0xFF, 0xFE, 0x00, 0x00, 0xFF, 0xF0, 0x0F, 0xFF, 0xFD, 0xF9, 0xFF, 0xFB, 0xFF, 0xFF, 0xFC, 0x00, 0x01, 0xFF, 0xF0, 0x0F, 0xFF, 0xFF, 0xFD, 0xFF, 0xFB, 0xFF, 0xFF, 0xFC, 0x00, 0x01, 0xFF, 0xF0, 0x1F, 0xFF, 0xFF, 0xFD, 0xFF, 0xFB, 0xFF, 0xFF, 0xFC, 0x00, 0x03, 0xFF, 0xF8, 0x3F, 0xFF, 0xFF, 0xFD, 0xFF, 0xFB, 0xFF, 0xFF, 0xF8, 0x00, 0x03, 0xFF, 0xFC, 0xFF, 0xFF, 0xFF, 0xFC, 0xFF, 0xF3, 0xFF, 0xFF, 0xF8, 0x00, 0x07, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFC, 0xFF, 0xF3, 0xFF, 0xFF, 0xF8, 0x00, 0x07, 0x80, 0x00, 0x3F, 0xFF, 0xFF, 0xFC, 0xFF, 0xF3, 0xFF, 0xFF, 0xF0, 0x00, 0x0F, 0x80, 0x00, 0x3F, 0xFF, 0xFF, 0xFE, 0xFF, 0xF7, 0xFF, 0xFF, 0xF0, 0x00, 0x0F, 0x00, 0x00, 0x3F, 0xFF, 0xFF, 0xFE, 0xFF, 0xF7, 0xFF, 0xFF, 0xF0, 0x00, 0x0F, 0x00, 0x00, 0x3F, 0xFF, 0xFF, 0xFE, 0x7F, 0xF7, 0xFF, 0xFF, 0xF0, 0x00, 0x1F, 0x00, 0x00, 0x3F, 0xFF, 0xFF, 0xFE, 0x7F, 0xF7, 0xFF, 0xFF, 0xE0, 0x00, 0x1F, 0xFE, 0x00, 0x7F, 0xFF, 0xFF, 0xFE, 0x7F, 0xF7, 0xFF, 0xFF, 0xE0, 0x00, 0x1F, 0xFE, 0x00, 0x7F, 0xFF, 0xFF, 0xFE, 0x7F, 0xF7, 0xFF, 0xFF, 0xE0, 0x00, 0x3F, 0xFE, 0x00, 0x7F, 0xFF, 0xFF, 0xFE, 0x7F, 0xF7, 0xFF, 0xFF, 0xE0, 0x00, 0x3F, 0xFE, 0x00, 0x7F, 0xFF, 0xFF, 0xFE, 0xFF, 0xF3, 0xFF, 0xFF, 0xE0, 0x00, 0x3F, 0xFC, 0x00, 0x7F, 0xFF, 0xFF, 0xFE, 0xFF, 0xF3, 0xFF, 0xFF, 0xE0, 0x00, 0x3F, 0xFC, 0x00, 0xFF, 0xFF, 0xFF, 0xFC, 0xFF, 0xF3, 0xFF, 0xFF, 0xE0, 0x00, 0x3F, 0xFC, 0x00, 0xFF, 0xFF, 0xFF, 0xFC, 0xFF, 0xFB, 0xFF, 0xFF, 0xE0, 0x00, 0x3F, 0xFC, 0x00, 0xFF, 0xFF, 0xFF, 0xFC, 0xFF, 0xFB, 0xFF, 0xFF, 0xE0, 0x00, 0x3F, 0xFC, 0x00, 0xFF, 0xFF, 0xFF, 0xFD, 0xFF, 0xFB, 0xFF, 0xFF, 0xE0, 0x00, 0x3F, 0xF8, 0x00, 0xFF, 0xFF, 0xFF, 0xFD, 0xFF, 0xFB, 0xFF, 0xFF, 0xE0, 0x00, 0x3F, 0xF8, 0x01, 0xFF, 0xFF, 0xFF, 0xFD, 0xFF, 0xF9, 0xFF, 0xFF, 0xE0, 0x00, 0x3F, 0xF8, 0x01, 0xFF, 0xFF, 0xFF, 0xF9, 0xFF, 0xFD, 0xFF, 0xFF, 0xE0, 0x00, 0x3F, 0xF8, 0x01, 0xFF, 0xFF, 0xFF, 0xF9, 0xFF, 0xFD, 0xFF, 0xFF, 0xF0, 0x00, 0x3F, 0xF8, 0x01, 0xFF, 0xFF, 0xFF, 0xFB, 0xFF, 0xFC, 0xFF, 0xFF, 0xF0, 0x00, 0x3F, 0xF0, 0x01, 0xFF, 0xFF, 0xFF, 0xFB, 0xFF, 0xFE, 0xFF, 0xFF, 0xF0, 0x00, 0x1F, 0xF0, 0x03, 0xFF, 0xFF, 0xFF, 0xF3, 0xFF, 0xFE, 0xFF, 0xFF, 0xF0, 0x00, 0x1F, 0xF0, 0x03, 0xFF, 0xFF, 0xFF, 0xF7, 0xFF, 0xFE, 0x7F, 0xFF, 0xF8, 0x00, 0x1F, 0xF0, 0x03, 0xFF, 0xFF, 0xFF, 0xE7, 0xFF, 0xFF, 0x7F, 0xFF, 0xF8, 0x00, 0x0F, 0xE0, 0x03, 0xFF, 0xFF, 0xFF, 0xEF, 0xFF, 0xFF, 0x3F, 0xFF, 0xF8, 0x00, 0x0F, 0xE0, 0x03, 0xFF, 0xFF, 0xFF, 0xEF, 0xFF, 0xFF, 0xBF, 0xFF, 0xFC, 0x00, 0x0F, 0xE0, 0x07, 0xFF, 0xFF, 0xFF, 0xCF, 0xFF, 0xFF, 0x9F, 0xCF, 0xFC, 0x00, 0x07, 0xE0, 0x07, 0xFF, 0xFF, 0xDF, 0xDF, 0xFF, 0xFF, 0xDF, 0xB7, 0xFE, 0x00, 0x07, 0xE0, 0x07, 0xFF, 0xFF, 0xEF, 0xBF, 0xFF, 0xFF, 0xCF, 0xFF, 0xFE, 0x00, 0x03, 0xC0, 0x07, 0xFF, 0xFF, 0x7F, 0x3F, 0xFF, 0xFF, 0xEF, 0x8F, 0xFF, 0x00, 0x01, 0xC0, 0x07, 0xFF, 0xFF, 0xDF, 0x7F, 0xFF, 0xFF, 0xE7, 0xDB, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x1E, 0x7F, 0xFF, 0xFF, 0xF3, 0xF3, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFD, 0x9C, 0xFF, 0xFF, 0xFF, 0xFB, 0xF5, 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF6, 0xFD, 0xFF, 0xFF, 0xFF, 0xFD, 0xFF, 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFB, 0xF9, 0xFF, 0xFF, 0xFF, 0xFC, 0xFE, 0xDF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xCD, 0xF3, 0xFF, 0xFF, 0xFF, 0xFE, 0x7F, 0xBF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xB7, 0xE7, 0xFF, 0xFF, 0xFF, 0xFF, 0x3F, 0x6F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xDF, 0xCF, 0xFF, 0xFF, 0xFF, 0xFF, 0x9F, 0xDF, 0x7F, 0xFF, 0xFF, 0xFF, 0xFE, 0x7F, 0x9F, 0xFF, 0xFF, 0xFF, 0xFF, 0xCF, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F, 0x3F, 0xFF, 0xFF, 0xFF, 0xFF, 0xE7, 0xFE, 0xEF, 0xFF, 0xFF, 0xFF, 0xD6, 0xFE, 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xF3, 0xFD, 0xEF, 0xFF, 0xFF, 0xFF, 0xE3, 0xFC, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF8, 0xFF, 0x7B, 0xFF, 0xFF, 0x7E, 0x6F, 0xF9, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0x7F, 0xBD, 0xBF, 0xFE, 0xB3, 0x3F, 0xE7, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x1F, 0xF1, 0x66, 0xFE, 0xBB, 0xFF, 0xCF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xCF, 0xFF, 0x6F, 0x7E, 0xB7, 0xFF, 0x3F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xE3, 0xFF, 0xF7, 0x7E, 0x7F, 0xFC, 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF8, 0xFF, 0xFF, 0xFF, 0xFF, 0xF1, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0x1F, 0xFF, 0xFF, 0xFF, 0x87, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xC3, 0xFF, 0xFF, 0xFC, 0x1F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 0x3F, 0xFF, 0xC0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x0F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0x03, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });
            p.addCmdQR(400, 20, "DK20250000000001");
            p.addCmdText(230, 50, 1, "e-FATURA");
            p.addCmdText(10, 140, 2, "DATAKENT.com");
            p.addCmd("PRINT 1,1");

            p.save2Disk("D:/Output.hx");


            #region AddressConfig
            //Bluetooth View 'da Gösterilen Adres -> 00:00:0E:03:40:0F //00000E03400F   RPP320-400f-E
            //0x0f, 0x40, 0x03, 0x0e, 0x0, 0x0  -> ulong -> 235094031
            var deviceID = macAddress2Ulong(deviceMacAddress);

            var socketAddress = new System.Net.SocketAddress((System.Net.Sockets.AddressFamily)32, 30);
            socketAddress[0] = checked((byte)32);//32 -> socket.AddressFamily
            var devIdArr = BitConverter.GetBytes(deviceID);
            for (int i = 0; i < 6; i++)
            {
                socketAddress[i + 2] = devIdArr[i];
            }

            Guid SerialPort_serviceId = Guid.Parse("{00001101-0000-1000-8000-00805f9b34fb}");
            var guidArray = SerialPort_serviceId.ToByteArray();
            for (int j = 0; j < 16; j++)
            {
                socketAddress[j + 10] = guidArray[j];
            }

            //SocketAddressToArray
            //static test -> var socAddr_data = new byte[] { 32, 0, 15, 64, 3, 14, 0, 0, 0, 0, 1, 17, 0, 0, 0, 0, 0, 16, 128, 0, 0, 128, 95, 155, 52, 251, 0, 0, 0, 0 };
            var socAddr_data = new byte[socketAddress.Size];
            for (int i = 0; i < socketAddress.Size; i++)
            {
                socAddr_data[i] = socketAddress[i];
            }
            #endregion


            Console.Write($"{deviceMacAddress} Devam etmek için..."); Console.ReadLine();

            if (!preCheck(deviceID)) return;

            // socket çağrısı ile bir soket oluştur
            int socketHandle = WinAPI.socket(WinAPI.AF_BTH, WinAPI.SOCK_STREAM, WinAPI.IPPROTO_GGP);
            if (socketHandle <= 0)
            {
                int errorCode = Marshal.GetLastWin32Error();
                Console.WriteLine($"Socket oluşturulamadı. Hata kodu: {errorCode}");
                return;
            }

            int result_c = WinAPI.connect(socketHandle, socAddr_data, 30);

            if (result_c != 0)
            {
                Console.WriteLine($"Bağlantı başarısız oldu. Hata kodu: {Marshal.GetLastWin32Error()}");
                return;
            }

            //Eğer connect çağrınız başarılı bir şekilde tamamlandıysa ve
            //hedef adresi zaten kontrol altındaysa, genellikle getpeername çağrısına ihtiyaç duyulmaz.
            //Ancak, bazı durumlarda(örneğin, yeniden teyit gerektiren hata ayıklama senaryolarında veya
            //adresin dinamik olarak değişebileceği bir durumda) kullanımı mantıklı olabilir.
            //byte[] rdata2 = new byte[30];
            //int rdata_sz = rdata2.Length;
            //int result_pn = WinAPI.getpeername(socketHandle, rdata2, ref rdata_sz);

            var socketFlags = System.Net.Sockets.SocketFlags.None;//None=0
            int size = p.data.Length;
            int result_s = WinAPI.send(socketHandle, p.data, size, (int)socketFlags);

            WinAPI.closesocket(socketHandle);

            Console.WriteLine($"Soket Handle: {socketHandle}");
        }

        static bool preCheck(ulong deviceID, bool devInfo = true, bool wsVer = true)
        {
            // Bluetooth cihaz bilgisi için yapı oluştur
            var deviceInfo = new WinAPI.BLUETOOTH_DEVICE_INFO(deviceID);

            int r_devInfo = WinAPI.BluetoothGetDeviceInfo(IntPtr.Zero, ref deviceInfo);
            if (r_devInfo != 0)
            {
                Console.WriteLine($"Bluetooth cihaz bilgisi alınamadı: {r_devInfo} {deviceID}");
                return false;
            }

            Console.WriteLine($"Cihaz Adresi: {deviceInfo.Address}");
            Console.WriteLine($"Cihaz Adı: {deviceInfo.szName}");
            Console.WriteLine($"Cihaz Sınıfı: {deviceInfo.ulClassofDevice}");
            Console.WriteLine($"Bağlı mı: {deviceInfo.fConnected}");
            Console.WriteLine($"Eşleştirilmiş mi: {deviceInfo.fRemembered}");
            Console.WriteLine($"Kimlik Doğrulandı mı: {deviceInfo.fAuthenticated}");


            ushort versionRequested = 0x0202; // Winsock 2.2  -> 0x0202 -> 514
            WinAPI.WSADATA wsadata;

            int r_startup = WinAPI.WSAStartup(versionRequested, out wsadata);
            if (r_startup != 0)
            {
                Console.WriteLine($"Winsock v2.2 sürüm kontrolü yapılamadı. Hata kodu: {r_startup}");
                return false;
            }

            Console.WriteLine("Winsock başarıyla başlatıldı!");
            Console.WriteLine($"Versiyon: {wsadata.wVersion >> 8}.{wsadata.wVersion & 0xFF}");
            Console.WriteLine($"Açıklama: {wsadata.szDescription}");

            return true;
        }

        static ulong macAddress2Ulong(string bluetoothAddress)
        {
            string cleanedAddress = bluetoothAddress.Replace(":", "").Replace("-", "");
            return ulong.Parse(cleanedAddress, NumberStyles.HexNumber);
        }        
    }
}
