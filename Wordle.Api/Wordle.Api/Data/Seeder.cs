namespace Wordle.Api.Data
{
    public static class Seeder
    {
        public static void Seed(AppDbContext context)
        {
            SeedCards(context);
            SeedWords(context);
        }
 
        public static void SeedWords(AppDbContext db)
        {
            if (!db.Words.Any())
            {
                var wordLines = System.IO.File.ReadAllLines("Content/Words.csv");
                foreach (var line in wordLines)
                {
                    var parts = line.Split(',');
                    var word = new Word()
                    {
                        Text = parts[0],
                        IsCommon = bool.Parse(parts[1])
                    };
                    db.Words.Add(word);
                }
                db.SaveChanges();
            }
        }

        public static void SeedCards(AppDbContext db)
        {
            if (!db.Cards.Any())
            {
                var cardLines = System.IO.File.ReadAllLines("Content/Cards.csv");
                foreach (var line in cardLines)
                {
                    var parts = line.Split(',');
                    var card = new Card()
                    {
                        CardValue = int.Parse(parts[0]),
                        Suit = parts[1]
                    };
                    db.Cards.Add(card);
                }
                db.SaveChanges();
            }
        }
        

    }
}
