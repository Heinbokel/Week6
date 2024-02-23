using System.Data;
using Dapper;
using Week6.models;

namespace Week6.repositories {

    public class TagsRepositoryDapperImpl: ITagsRepository {

        private static readonly string GET_USER_TAGS = @"
            SELECT
                UserTags.TagID,
                UserTags.UserID,
                Tags.TagName
            FROM
                UserTags
            JOIN
                Tags
            ON
                UserTags.TagID = Tags.TagID
            WHERE
                UserTags.UserId = @USER_ID";

        private readonly IDbConnection _connection;

        public TagsRepositoryDapperImpl(IDbConnection connection) {
            this._connection = connection;
        }

        public List<Tag> GetTagsByUserId(int userId) {
            var Params = new { 
                USER_ID = userId
            };

            return this._connection.Query<Tag>(GET_USER_TAGS, Params).ToList();
        }

    }

}