
namespace MDrop.MagicDrop
{
    internal class MagicDropStatus
    {
        public int Status { get; set; }
        public int Auth_Err { get; set; }
        public int Bad_Post { get; set; }
        public int Already_Registered { get; set; }

        public override string ToString()
        {
            return $"Status:{Status}   " +
                $"Auth_Err:{Auth_Err}   " +
                $"Bad_Post:{Bad_Post}   " +
                $"Already_Registered:{Already_Registered}";
        }
    }
}
