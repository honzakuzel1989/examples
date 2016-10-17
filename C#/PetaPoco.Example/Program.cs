namespace PetaPoco.Example
{
    class Program
    {
        class TKANAL
        {
            // Case insensitive (!)
            public string ID { get; set; }
            public string OZNACENI { get; set; }
        }

        class TSCHEMA
        {
            public string ID { get; set; }
            public int TYP { get; set; }
        }

        class TSCHEMAKANAL
        {
            public string ID_SCHEMA { get; set; }
            public string ID_KANAL { get; set; }
            public TSCHEMA SCHEMA { get; set; }
        }

        static void Main(string[] args)
        {
            var db = new Database("ConnectionString");

            var result = db.Fetch<TSCHEMAKANAL, TSCHEMA>("SELECT * FROM TSCHEMAKANAL , TSCHEMA WHERE TSCHEMA.ID = TSCHEMAKANAL.ID_SCHEMA");

            //var result = db.Query<dynamic>("select * from TKANAL");
            //var resultInt = db.Fetch<int>($"SELECT ID_TC FROM TKANAL WHERE ID_SUBSYSTEM=@0 AND PLATNOST=@1 GROUP BY ID_TC", 13, 1);

            //var db = new Database("ConnectionString");
            //var result = db.Query<Kanal>("select * from TKANAL");

            ////var result = db.Query<dynamic>("select * from TKANAL");
            ////var resultInt = db.Fetch<int>($"SELECT ID_TC FROM TKANAL WHERE ID_SUBSYSTEM=@0 AND PLATNOST=@1 GROUP BY ID_TC", 13, 1);

            //int counter = 0;
            //foreach (var r in result)
            //{
            //    Console.WriteLine($"id={r.ID},oznaceni={r.Title}");
            //    counter++;
            //}

            //Console.WriteLine(counter);
            //Console.ReadLine();
        }
    }
}
