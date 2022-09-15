// See https://aka.ms/new-console-template for more information

List<kuldetes> kuldetesek = new List<kuldetes>();
kuldetes temp = new kuldetes();
string inDump;
string[] daranok = new string[7];

FileStream fs = new FileStream("kuldetesek.csv", FileMode.Open);
StreamReader sr = new StreamReader(fs);

while (!sr.EndOfStream)
{
    inDump = sr.ReadLine();
    daranok = inDump.Split(';');
    temp.Kod = daranok[0];
    temp.Date = daranok[1];
    temp.Name = daranok[2];
    temp.Day = Convert.ToInt32(daranok[3]);
    temp.Hour = Convert.ToInt32(daranok[4]);
    temp.Lname = daranok[5];
    temp.Leg = Convert.ToInt32(daranok[6]);
    kuldetesek.Add(temp);
    temp = new kuldetes();
}
fs.Close();

Console.WriteLine("3. feladat:");
Console.WriteLine("\tÖsszesen {0} alkalommal indítottak űrhajót.", kuldetesek.Count);

Console.WriteLine("4. feladat:");
int utasok = 0;
foreach (var item in kuldetesek)
{
    utasok += item.Leg;
}
Console.WriteLine("\t{0} utas indult az űrbe összesen.", utasok);

Console.WriteLine("5. feladat:");
int kev = 0;
foreach (var item in kuldetesek)
{
    if (item.Leg < 5)
    {
        kev++;
    }
}
Console.WriteLine("\tÖsszesen {0} alkalommal küldtek kevesebb, mint 5 embert az űrbe.", kev);

Console.WriteLine("6. feladat:");
int tempi = 0;
foreach (var item in kuldetesek)
{
    if (item.Name == "Columbia")
    {
        tempi++;
    }
}
Console.WriteLine(tempi);
Console.WriteLine("\t{0} asztronauta volt a Columbia fedélzetén annak utolsó útján", kuldetesek[tempi].Leg);

Console.WriteLine("7. feladat");
int max = 0;
for (int i = 0; i < kuldetesek.Count; i++)
{
    if ((kuldetesek[i].Day*24 + kuldetesek[i].Hour) > (kuldetesek[max].Day * 24 + kuldetesek[max].Hour))
    {
        max = i;
    }
}
Console.WriteLine("\tA leghosszabb ideig  a {0} volt az űrben a {1} küldetés során.",kuldetesek[max].Name, kuldetesek[max].Kod);
Console.WriteLine("\tÖsszesen {0} órát volt távol a Földtöl", (kuldetesek[max].Hour + kuldetesek[max].Day*24));