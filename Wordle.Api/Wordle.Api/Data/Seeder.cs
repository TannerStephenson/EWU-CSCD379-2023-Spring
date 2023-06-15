namespace Wordle.Api.Data
{
    public static class Seeder
    {
        public static void Seed(AppDbContext context)
        {
            SeedCards(context);
            SeedChips(context);
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
                        Suit = parts[1],
                        Character = parts[2]
                    };
                    db.Cards.Add(card);
                }
                db.SaveChanges();
            }
        }

        public static void SeedChips(AppDbContext db)
        {
            if (!db.Chips.Any())
            {
                var newPlayer = new Chip()
                {
                    Name = "Player 1",
                    ChipCount = 1000,
                    ChipId = Guid.NewGuid()
                };
                db.Chips.Add(newPlayer);
            }
            db.SaveChanges();
            
        }
        

    }
}
