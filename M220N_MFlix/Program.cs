// See https://aka.ms/new-console-template for more information
using MongoDB.Bson;
using MongoDB.Driver;

Console.WriteLine("Hello, World!");


var settings = MongoClientSettings.FromConnectionString("mongodb+srv://m220n:m220n-mongodb-basics@cluster0.fz5cg.mongodb.net/?retryWrites=true&w=majority");
settings.ServerApi = new ServerApi(ServerApiVersion.V1);
var client = new MongoClient(settings);

var dbs = client.ListDatabases().ToList();

Console.WriteLine("The list of databases on this server is: ");
foreach (var db in dbs)
{
    Console.WriteLine(db.GetValue("name"));
    
}

Console.WriteLine("Connecting to DataBase : sample.mflix.movies");
var database = client.GetDatabase("sample_mflix");
var collection = database.GetCollection<BsonDocument>("movies");

Console.WriteLine("Running find query");
var result = collection.Find(new BsonDocument()).SortByDescending(m => m["runtime"]).Skip(9).Limit(1).ToList();

Console.WriteLine("Results");
foreach (var item in result)
{
    Console.WriteLine($"Title: {item.GetValue("title")}, runtime : {item.GetValue("runtime")}");
}




