namespace Week6.models {

    public class User {

        public int UserId { get; set; }
        public string Username { get;  set;}
        public string Email { get; set; }
        public decimal? CurrentLatitude { get; set; }
        public decimal? CurrentLongitude { get; set; }
        public List<Tag> UserTags { get; set; } = [];

    }

}