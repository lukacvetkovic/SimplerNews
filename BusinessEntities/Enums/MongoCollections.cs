namespace BusinessEntities.Enums
{
    public sealed class MongoCollections
    {
        public static readonly MongoCollections News = new MongoCollections("News");

        private MongoCollections(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static implicit operator string(MongoCollections op) { return op.Value; }
    }
}
