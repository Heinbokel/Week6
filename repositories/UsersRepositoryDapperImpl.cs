using System.Data;
using Dapper;
using Week6.models;

namespace Week6.repositories {

    public class UsersRepositoryDapperImpl: IUsersRepository {

        private static readonly string GET_USERS_SQL = @"
            SELECT
                UserID,
                Username,
                Email,
                CurrentLatitude,
                CurrentLongitude
            FROM
                Users";

        private readonly IDbConnection _connection;

        public UsersRepositoryDapperImpl(IDbConnection connection) {
            this._connection = connection;
        }

        public List<User> GetUsers() {
            return this._connection.Query<User>(GET_USERS_SQL).ToList();
        }

    }

}