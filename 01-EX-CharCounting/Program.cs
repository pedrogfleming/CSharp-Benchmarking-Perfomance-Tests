// TODO: fix this method - remove boxing & unboxing, and return correct result
string name = "John Doe";
name = name.ToLower();
var result = new Dictionary<char, int>();
foreach (char c in name)
{
    if(c == ' ') { continue; }
    if (result.ContainsKey(c))
    {
        result[c]++;
    }
    else
    {
        result.Add(c, 1);
    }    
}
foreach (var item in result)
{
    Console.WriteLine($"{item.Key} : {item.Value}");
}