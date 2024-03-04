namespace OutstandingPersonApp
{
    public class Author:Person
    {
        public int BooksPublished { get; set; }

        public Author()
        {
            
        }
        public Author(string name, int booksPublished)
            :base(name) 
        {
            BooksPublished = booksPublished;
        }

        public override bool IsOutstanding()
        {
            return this.BooksPublished > 5;
        }
    }
}
