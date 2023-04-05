using CRUDUsingMongo.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CRUDUsingMongo.Services;

public class BooksService
{
    private readonly IMongoCollection<Book> booksCollection;

    public BooksService (IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSetteing)
    {
        var mongoClient = new MongoClient(bookStoreDatabaseSetteing.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(bookStoreDatabaseSetteing.Value.DatabaseName);

        booksCollection = mongoDatabase.GetCollection<Book>(bookStoreDatabaseSetteing.Value.BooksCollectionName);
    }

    public async Task<List<Book>> GetAsync() =>
        await booksCollection.Find(_=> true).ToListAsync();
    public async Task<Book?> GetAsync(int id) =>
        await booksCollection.Find(x=> x.Id== id).FirstOrDefaultAsync();
    public async Task CreateAsync(Book newBook) =>
        await booksCollection.InsertOneAsync(newBook);
    public async Task UpdateAsync(int id, Book updateBook) =>
        await booksCollection.ReplaceOneAsync(x => x.Id == id, updateBook);
    public async Task RemoveAsync(int id) =>
        await booksCollection.DeleteOneAsync(x => x.Id == id);
}
