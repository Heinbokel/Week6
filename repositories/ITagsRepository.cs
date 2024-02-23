using Week6.models;

namespace Week6.repositories {

    public interface ITagsRepository {

        public List<Tag> GetTagsByUserId(int userId);

    }

}