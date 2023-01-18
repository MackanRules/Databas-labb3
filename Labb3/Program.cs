//Labb 3, databaskursen, Marcus Gustafsson (2023-01-19)

using MongoDB.Driver;
using MongoDB.Bson;

namespace Labb3
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            IStringIO io;
            IProductDAO DAO;

            DAO = new MongoDAO("");
            io = new TextIO();
            InventoryController controller = new InventoryController(io, DAO);
            controller.Start();

        }

    }

}













//Lite gammalt från lektioner

//void FindHighExamScore()
//{
//    MongoClient dbClient = new MongoClient("mongodb+srv://Atlasname:Atlaspass@cluster0.eybwfy1.mongodb.net/?retryWrites=true&w=majority");

//    var database = dbClient.GetDatabase("TestDB");
//    var collection = database.GetCollection<BsonDocument>("Tests");

//    var highExamScoreFilter = Builders<BsonDocument>.Filter.ElemMatch<BsonValue>(
//        "scores", new BsonDocument { { "type", "exam" },
//                    {"score", new BsonDocument { { "$gte", 70 } }}
//    });

//    var highExamScores = collection.Find(highExamScoreFilter).ToList();

//    var cursor = collection.Find(highExamScoreFilter).ToCursor();
//    foreach (var document in cursor.ToEnumerable())
//    {
//        Console.WriteLine(document);
//    }
//}

//void FindAndSort()
//{
//    MongoClient dbClient = new MongoClient("mongodb+srv://Atlasname:Atlaspass@cluster0.eybwfy1.mongodb.net/?retryWrites=true&w=majority");

//    var database = dbClient.GetDatabase("TestDB");
//    var collection = database.GetCollection<BsonDocument>("Tests");

//    var highExamScoreFilter = Builders<BsonDocument>.Filter.ElemMatch<BsonValue>(
//        "scores", new BsonDocument { { "type", "exam" },
//                    {"score", new BsonDocument { { "$gte", 70 } }}
//    });

//    var sort = Builders<BsonDocument>.Sort.Descending("student_id");

//    var highestExamScores = collection.Find(highExamScoreFilter).Sort(sort);
//    Console.WriteLine(highestExamScores);
//}

//void UpdateOneArray()
//{
//    MongoClient dbClient = new MongoClient("mongodb+srv://Atlasname:Atlaspass@cluster0.eybwfy1.mongodb.net/?retryWrites=true&w=majority");

//    var database = dbClient.GetDatabase("TestDB");
//    var collection = database.GetCollection<BsonDocument>("Tests");

//    var arrayFilter = Builders<BsonDocument>.Filter.Eq("student_id", 1) & Builders<BsonDocument>.Filter.Eq("scores.type", "quiz");

//    var arrayUpdate = Builders<BsonDocument>.Update.Set("scores.$.score", 65);
//    collection.UpdateOne(arrayFilter, arrayUpdate);
//}
