using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonExamples
{
    class BitwiseNotOperator
    {
        static void Main()
        {
            byte b1 = 254;
            byte b2 = (byte)~b1;

            byte c = 153;
            byte d = 104;
            byte f = (byte)(c & d);

            int a = 5;
            int mask = 3;
            int encrypted = a ^ mask; // 5 XOR 3 ile şifreleme
            int descrypted = encrypted ^ mask; // Şifreyi tekrar XOR ile çözme

            int x = 195;
            int y = 26;
            x = x ^ y;
            y = y ^ x;
            x = x ^ y;

            byte k = 0xFF;
            k = (byte)(k << 4);
            Console.WriteLine("k: " + k);
            k = (byte)(k >> 3);
            Console.WriteLine("k: " + k);

            Console.WriteLine(b2);
            Console.WriteLine(f);
            Console.WriteLine(encrypted);
            Console.WriteLine(descrypted);
            Console.WriteLine("x={0}\ny={1}", x, y);
            Console.ReadLine();
        }
    }
}

//Kod Analizi
//Bitwise NOT Operatörü ~:

//~operatörü, bir sayının tüm bitlerini tersine çevirir.Bu, her 1 bitini 0 yapar ve her 0 bitini 1 yapar.
//b1 değeri 254 olduğu için, önce bunu ikili (binary) olarak gösterelim.
//254'ü İkili (Binary) Formatta Gösterme:


//byte türü 8 bitlik bir veri türüdür, yani 254 sayısı 8 bit içinde temsil edilebilir.
//254 sayısının ikili gösterimi: 1111 1110
//Bitwise NOT Uygulaması:

//~b1 ifadesi, b1'in tüm bitlerini tersine çevirir.
//1111 1110 bitlerini ters çevirince, 0000 0001 elde ederiz.
//Sonuç Olarak b2 Değerini Hesaplama:

//0000 0001 ikili gösterimi 1 sayısına karşılık gelir.
//Bu işlem sonucunda b2 değişkeni 1 değerini alır.

//------------------------------------------------------------------------------

//Adım 1: x = x ^ y;
//Bu adımda, x değişkenini kendisiyle y değişkeninin XOR’u olarak güncelliyoruz.

//Başlangıçta:

//x = 195 (binary olarak 1100 0011)
//y = 26 (binary olarak 0001 1010)
//XOR işlemi(x ^ y):

//  1100 0011  (195)
//XOR 0001 1010  (26)
//  --------
//  1101 1001  (217)
//Bu işlem sonucunda x = 217 olur.Şu anda:

//x = 217
//y = 26 (değişmedi)
//Adım 2: y = y ^ x;
//Bu adımda y değişkenini, kendisiyle güncellenmiş x(yani 217) değerinin XOR’u olarak güncelliyoruz.

//y = 26 (binary olarak 0001 1010)

//x = 217 (binary olarak 1101 1001)

//XOR işlemi(y ^ x):

//  0001 1010  (26)
//XOR 1101 1001  (217)
//  --------
//  1100 0011  (195)
//Bu işlem sonucunda y = 195 olur.Şu anda:

//x = 217 (değişmedi)
//y = 195
//Adım 3: x = x ^ y;
//Son olarak, x değişkenini güncellenmiş x ve yeni y değerlerinin XOR’u olarak güncelliyoruz.

//x = 217 (binary olarak 1101 1001)

//y = 195 (binary olarak 1100 0011)

//XOR işlemi(x ^ y):

//  1101 1001  (217)
//XOR 1100 0011  (195)
//  --------
//  0001 1010  (26)
//Bu işlem sonucunda x = 26 olur.Son durumda:

//x = 26
//y = 195

//------------------------------------------------------------------------------------------
//Başlangıç Değeri:
//k = 0xFF: Bu, onaltılık(hexadecimal) bir değer olup, 0xFF değeri 11111111 (binary olarak) olarak temsil edilir.
//k'nın başlangıç değeri: 11111111 (binary) yani 255 (ondalık).
//1. Adım: k = (byte)(k << 4);
//<< operatörü: Bu, sola kaydırma(left shift) işlemidir.Bu işlemde, sayının her bir biti belirtilen sayıda sola kaydırılır ve sağ taraftan boşluklar 0 ile doldurulur.

//k = 0xFF = 11111111 (binary)

//k << 4 işlemi, bu değeri 4 bit sola kaydırır:

//11111111  (k = 0xFF)
//<< 4
//--------
//11110000  (yeni k = 0xF0)
//Sonuç: 11110000 (binary), yani 240 (ondalık), bu da 0xF0 (onaltılık) olarak yazılabilir.

//Sonraki değeri:

//k = 0xF0 (yeni değeri).
//2. Adım: k = (byte) (k >> 3);
//>> operatörü: Bu, sağa kaydırma(right shift) işlemidir.Bu işlemde, sayının her bir biti belirtilen sayıda sağa kaydırılır ve sol taraftan boşluklar 0 ile doldurulur.

//k = 0xF0 = 11110000 (binary)

//k >> 3 işlemi, bu değeri 3 bit sağa kaydırır:

//11110000  (k = 0xF0)
//>> 3
//--------
//00011110  (yeni k = 0x1E)
//Sonuç: 00011110 (binary), yani 30 (ondalık), bu da 0x1E (onaltılık) olarak yazılabilir.

//Sonraki değeri:

//k = 0x1E (yeni değeri).
//Sonuç:
//Kodun çıktısı şu şekilde olur:

//k: 240
//k: 30
//Özetle:
//Sol Kaydırma(<<): Sayının bitlerini sola kaydırır.Bu işlemde sağ taraftaki boşluklar 0 ile doldurulur.
//Sağ Kaydırma (>>): Sayının bitlerini sağa kaydırır.Bu işlemde sol taraftaki boşluklar 0 ile doldurulur.
//İlk kaydırma işlemi (4 bit sola) sonucu k değeri 240 oldu, ardından ikinci kaydırma işlemi(3 bit sağa) sonucu k değeri 30 oldu.

