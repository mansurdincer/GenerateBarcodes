int reserveDigits = 0;
string barcodeRoot = "";

while (barcodeRoot.Length is > 12 or 0)
{
    Console.WriteLine("Barkod kök Numarasını girin (max 12 haneli): ");
    barcodeRoot = Console.ReadLine();
}

while (reserveDigits is < 1 or > 4)
{
    Console.WriteLine("Kaç haneli barkod üretileceğini girin (max 4 haneli): ");

    try
    {
        reserveDigits = Convert.ToInt32(Console.ReadLine());
    }
    catch (System.OverflowException)
    {
        Console.WriteLine("Lütfen 1 ile 4 arasında bir sayı girin.");
    }

}


//define a barcodelist
List<string> barcodeList = new List<string>();

for (int i = 1; i < Math.Pow(10, reserveDigits); i++)
{
    string barcode = barcodeRoot + i.ToString().PadLeft(reserveDigits, '0');

    int controlBit = 0;
    for (int j = 0; j < barcode.Length; j++)
    {
        if (j % 2 == 0)
        {
            controlBit += int.Parse(barcode[j].ToString());
        }
        else
        {
            controlBit += int.Parse(barcode[j].ToString()) * 3;
        }
    }

    controlBit = 10 - (controlBit % 10);
    if (controlBit == 10)
    {
        controlBit = 0;
    }

    barcode += controlBit.ToString();
    barcodeList.Add(barcode);
    //Console.WriteLine(barcode);

}

//save barcodeList into txt file with file name barcodeRoot , specify the path with logined windows user name
string path = @"C:\Users\";
path += Environment.UserName;
path += @"\Desktop\";
path += "EAN_";
path += barcodeRoot;
path += ".txt";

File.WriteAllLines(path, barcodeList);

//show the path of txt file
Console.WriteLine("Barkodlar " + path + " dosyasına kaydedildi.");

return;