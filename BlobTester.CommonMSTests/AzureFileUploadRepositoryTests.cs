﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace BlobTester.Common.MSTests
{
    [TestClass()]
    public class AzureFileUploadRepositoryTests
    {
        [TestMethod()]
        public void UploadFileTest()
        {
            const string newFileBlob = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur maximus ex nec nibh suscipit, eu iaculis est luctus. Donec et nunc lectus. Morbi finibus mauris lacus, at porttitor felis tristique id. Aenean non dolor mattis, dictum enim eget, elementum erat. Donec gravida ultrices lacinia. Fusce eu nibh faucibus, vulputate lectus at, fermentum nisi. Phasellus fringilla risus a odio sodales, id cursus felis varius. Phasellus a ultrices nibh.
                                        Proin pretium consequat semper. Ut varius maximus vehicula. Sed vulputate quam eu quam ultrices, sed vehicula justo molestie. Vivamus libero turpis, finibus pretium turpis at, iaculis convallis felis. Vivamus facilisis at nunc ut maximus. Vestibulum et commodo tellus. Aliquam quam nunc, vehicula ut nulla in, pulvinar fermentum tortor.
                                        Sed eu bibendum mauris, vitae condimentum tortor. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras quis elit nec orci aliquam interdum quis sed nibh. Integer a pulvinar turpis, a pharetra odio. Morbi vestibulum sapien ac dolor malesuada dictum. Ut efficitur posuere arcu, eu consectetur risus bibendum eu. Pellentesque vehicula, justo id sodales pharetra, enim tortor tempus purus, eu tristique dui felis ac nisi. Aliquam egestas justo eros, quis venenatis lectus fringilla eget. Donec vestibulum diam et gravida convallis. Nunc pulvinar risus ac scelerisque iaculis.
                                        Fusce ornare mauris sit amet nunc pellentesque dapibus. Duis vulputate commodo sem vitae porttitor. Integer condimentum nisi vitae gravida posuere. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam eros turpis, efficitur quis molestie vitae, vestibulum sed dui. Nulla maximus tortor vitae magna tincidunt, id molestie mi tempor. Vestibulum sollicitudin rhoncus enim eu pulvinar. Sed eu rhoncus dui, quis pellentesque erat. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Fusce pretium, ligula at euismod blandit, libero massa rhoncus justo, nec volutpat quam ante sed risus. Donec augue nunc, tempor nec tincidunt pharetra, dictum ac ligula. Nullam condimentum libero nec lectus pellentesque mattis. Sed sagittis posuere ligula at bibendum. Phasellus tellus est, aliquet a tristique et, posuere eget metus. Curabitur a dapibus mauris, rhoncus scelerisque neque. Vivamus aliquam dolor vitae placerat vulputate.
                                        Donec interdum velit vel elit rhoncus facilisis. Proin aliquam, orci sed facilisis posuere, nibh orci rhoncus dui, id ullamcorper nisl sem id nulla. Nunc ullamcorper vestibulum semper. In auctor sagittis arcu sed faucibus. Quisque interdum pretium lacus in sollicitudin. Vestibulum sed dapibus sem, eu dignissim neque. Pellentesque dignissim, tellus vel mattis vestibulum, elit purus aliquet odio, a ultricies nunc erat viverra sapien. Vestibulum auctor et risus id scelerisque. Nunc pulvinar sapien ac enim gravida, condimentum cursus justo commodo.
                                        Maecenas quis laoreet dolor. Fusce nec lectus accumsan dui pellentesque laoreet. Aliquam at bibendum mauris. Nullam euismod eros et erat sodales semper. Proin placerat aliquam nulla vel imperdiet. Integer dapibus non augue mattis eleifend. Nulla at velit sed neque tristique auctor et in lorem. Cras eleifend condimentum sollicitudin. Maecenas quis efficitur ante, in suscipit enim. Fusce volutpat, ipsum sit amet volutpat interdum, nisl risus consectetur felis, sit amet tempus leo odio nec massa.
                                        Mauris tempor mauris eget massa semper, vitae dictum quam molestie. In semper dolor velit, id ullamcorper nulla ultrices a. Suspendisse vel lorem scelerisque, ullamcorper diam vitae, aliquet justo. Praesent et pharetra arcu. Maecenas efficitur tortor turpis, eu tincidunt mauris tristique vitae. Vestibulum sed nisl sapien. In laoreet metus ac orci sagittis, at venenatis tellus aliquam. Vivamus ac bibendum dui. Suspendisse viverra nisi id vestibulum venenatis. Aliquam euismod aliquam volutpat. Curabitur lobortis efficitur metus at faucibus. Vestibulum ultricies iaculis dictum. Nullam eleifend vehicula sem, lobortis aliquet nisl tincidunt sit amet. Integer sed eros vel velit rhoncus porta. Aenean vestibulum arcu eget vestibulum aliquam. Vestibulum fringilla tincidunt dictum.
                                        Mauris ornare egestas tincidunt. Ut accumsan aliquam sollicitudin. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Cras sit amet mi metus. Suspendisse gravida a diam a dictum. Donec elementum ligula et turpis condimentum dapibus viverra vel sem. Nunc eget ex ac libero lobortis faucibus. Pellentesque placerat, erat a blandit viverra, ante urna blandit felis, at efficitur enim nisi sed lectus. Phasellus posuere, nisl vel bibendum fermentum, purus nunc aliquam nisl, fringilla imperdiet nulla dui id turpis.
                                        Donec quis ligula vestibulum, auctor ligula eu, gravida tellus. Integer sollicitudin leo libero, id venenatis quam ullamcorper a. Etiam et quam sed nisi congue blandit. Cras a est nibh. Sed sollicitudin erat et lorem porta vehicula. Vivamus tempus tristique nisi posuere rhoncus. Cras dapibus mollis suscipit. Nullam ac diam est. Maecenas varius est nec tristique mollis. Praesent tempor et nulla id sollicitudin. Nulla ac nibh risus. Suspendisse at quam pharetra, laoreet odio et, facilisis libero.
                                        Integer in nunc facilisis, placerat eros sed, venenatis libero. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur laoreet id sapien sit amet venenatis. In hac habitasse platea dictumst. Nulla molestie, felis nec pellentesque facilisis, risus nulla interdum eros, eu imperdiet eros ligula in ante. Vivamus efficitur mauris quis quam sodales, ac suscipit dui placerat. Cras sit amet iaculis sem. Vivamus porta eleifend dignissim. In id nibh ullamcorper, eleifend nisl vitae, facilisis ex. Morbi vitae erat aliquet, dapibus purus non, accumsan libero. Nullam at erat nec mi finibus rutrum eu ut dui. Nullam sit amet justo sed nunc ultrices sodales nec vitae nulla. Quisque commodo finibus nunc sit amet suscipit. Vestibulum ultrices tortor at dignissim malesuada.";

            var byteArray = Encoding.ASCII.GetBytes(newFileBlob);

            var azureFileUploadRepository = new AzureFileUploadRepository();

            Assert.AreEqual(azureFileUploadRepository.StorageConnectionString, "[StorageConString]");

            var fileName = Guid.NewGuid();

            var fileInfo = azureFileUploadRepository.UploadFile(byteArray, fileName);

            Assert.IsNotNull(fileInfo);
        }
    }
}