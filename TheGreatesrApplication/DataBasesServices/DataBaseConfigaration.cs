using MySql.Data.MySqlClient;

namespace TheGreatesrApplication.DataBasesServices
{
    public class DataBaseConfigaration
    {
        public static void PrepareDatabase()
        {
            using MySqlConnection connection = new DataBaseSQL().CreateSchemaConnection();
            connection.Open();

            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "CREATE DATABASE IF NOT EXISTS animalregistry";
            command.ExecuteNonQuery();

            command.CommandText = "USE animalregistry";
            command.ExecuteNonQuery();

            command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS animalKind(
                    idkind_of_animal INTEGER PRIMARY KEY auto_increment,
                    kind VARCHAR(45)
                    )";
            command.ExecuteNonQuery();
            command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS skill(
                    idskill INTEGER PRIMARY KEY auto_increment,
                    idkind_of_animal INTEGER,
                    skill VARCHAR(45),
                    FOREIGN KEY (idkind_of_animal) REFERENCES kind_of_animal (idkind_of_animal) ON DELETE CASCADE
                    )";
            command.ExecuteNonQuery();
            command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS animal(
                    idanimal INTEGER PRIMARY KEY auto_increment,
                    idkind_of_animal INTEGER,
                    name VARCHAR(45),
                    birthday DATETIME,
                    description VARCHAR(250),
                    FOREIGN KEY (idkind_of_animal) REFERENCES kind_of_animal (idkind_of_animal) ON DELETE CASCADE
                    )";
            command.ExecuteNonQuery();
            command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS animalSkill(
                    idanimal_skill INTEGER PRIMARY KEY auto_increment,
                    idanimal INTEGER,
                    idskill INTEGER,
                    FOREIGN KEY (idanimal) REFERENCES animal (idanimal) ON DELETE CASCADE,
                    FOREIGN KEY (idskill) REFERENCES skill (idskill) ON DELETE CASCADE
                    )";
            command.ExecuteNonQuery();
        }
    }
}
