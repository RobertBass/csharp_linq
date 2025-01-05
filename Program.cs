class Program {
    static void Main(String[] args) {
        var frutas = new string[]{
            "Sandia",
            "Fresa",
            "Mango",
            "Mango de Azucar",
            "Mango de Tomy"
        };

        var mangoList = frutas.Where(p=> p.StartsWith("Mango")).ToList();

        mangoList.ForEach(p=> Console.WriteLine(p));
    }
}


