﻿using Xunit;

namespace PeNet.Test.Structures
{
    public class Resources_Test
    {
        [Fact]
        public void Resources_GivenAPEFile_VsVersionInfoSet()
        {
            var peFile = new PeFile("./Binaries/firefox_invalid_x64.exe");
            var vsVersionInfo = peFile.Resources.VsVersionInfo;

            Assert.Equal((ushort) 0x03E8, vsVersionInfo.wLength);
            Assert.Equal((ushort) 0x0034, vsVersionInfo.wValueLength);
            Assert.Equal((ushort) 0x0000, vsVersionInfo.wType);
            Assert.Equal("VS_VERSION_INFO", vsVersionInfo.szKey);
            Assert.Equal((ushort) 0x0000, vsVersionInfo.Padding1);

            Assert.Equal(0xFEEF04BD, vsVersionInfo.VsFixedFileInfo.dwSignature);
            Assert.Equal((uint) 0x00010000, vsVersionInfo.VsFixedFileInfo.dwStrucVersion);
            Assert.Equal((uint) 0x00390000, vsVersionInfo.VsFixedFileInfo.dwFileVersionMS);
            Assert.Equal((uint) 0x00021995, vsVersionInfo.VsFixedFileInfo.dwFileVersionLS);
            Assert.Equal((uint) 0x00390000, vsVersionInfo.VsFixedFileInfo.dwProductVersionMS);
            Assert.Equal((uint) 0x00020000, vsVersionInfo.VsFixedFileInfo.dwProductVersionLS);
            Assert.Equal((uint) 0x0000003F, vsVersionInfo.VsFixedFileInfo.dwFileFlagsMask);
            Assert.Equal((uint) 0x00000000, vsVersionInfo.VsFixedFileInfo.dwFileFlags);
            Assert.Equal((uint) 0x00000004, vsVersionInfo.VsFixedFileInfo.dwFileOS);
            Assert.Equal((uint) 0x00000002, vsVersionInfo.VsFixedFileInfo.dwFileType);
            Assert.Equal((uint) 0x00000000, vsVersionInfo.VsFixedFileInfo.dwFileSubType);
            Assert.Equal((uint) 0x00000000, vsVersionInfo.VsFixedFileInfo.dwFileDateMS);
            Assert.Equal((uint) 0x00000000, vsVersionInfo.VsFixedFileInfo.dwFileDateLS);

            Assert.Equal((ushort) 0x0346, vsVersionInfo.StringFileInfo.wLength);
            Assert.Equal((ushort) 0x0000, vsVersionInfo.StringFileInfo.wValueLength);
            Assert.Equal((ushort) 0x0001, vsVersionInfo.StringFileInfo.wType);
            Assert.Equal("StringFileInfo", vsVersionInfo.StringFileInfo.szKey);

            Assert.Equal((ushort) 0x0322, vsVersionInfo.StringFileInfo.StringTable[0].wLength);
            Assert.Equal((ushort) 0x0000, vsVersionInfo.StringFileInfo.StringTable[0].wValueLength);
            Assert.Equal((ushort) 0x0001, vsVersionInfo.StringFileInfo.StringTable[0].wType);
            Assert.Equal("000004b0", vsVersionInfo.StringFileInfo.StringTable[0].szKey);

            Assert.Equal((ushort) 0x0018, vsVersionInfo.StringFileInfo.StringTable[0].String[0].wLength);
            Assert.Equal((ushort) 0x0000, vsVersionInfo.StringFileInfo.StringTable[0].String[0].wValueLength);
            Assert.Equal((ushort) 0x0001, vsVersionInfo.StringFileInfo.StringTable[0].String[0].wType);
            Assert.Equal("Comments", vsVersionInfo.StringFileInfo.StringTable[0].String[0].szKey);


            Assert.Equal((ushort)0x00AC, vsVersionInfo.StringFileInfo.StringTable[0].String[1].wLength);
            Assert.Equal((ushort)0x0044, vsVersionInfo.StringFileInfo.StringTable[0].String[1].wValueLength);
            Assert.Equal((ushort)0x0001, vsVersionInfo.StringFileInfo.StringTable[0].String[1].wType);
            Assert.Equal("LegalCopyright", vsVersionInfo.StringFileInfo.StringTable[0].String[1].szKey);
            Assert.Equal("\u00a9Firefox and Mozilla Developers; available under the MPL 2 license.", vsVersionInfo.StringFileInfo.StringTable[0].String[1].Value[0]);
        }
    }
}