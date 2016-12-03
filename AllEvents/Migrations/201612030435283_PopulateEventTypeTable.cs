namespace AllEvents.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateEventTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO EventTypes(Name) VALUES ('Birthdays')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Business Dinners')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Conferences')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Cultural Events')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Engagement Parties')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Family Events')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Farewell Parties')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Fundraising Events')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Graduation Parties')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Holiday Events')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Meetings')");           
            Sql("INSERT INTO EventTypes(Name) VALUES ('Music & Concerts')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Networking Events')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Opening Ceremonies')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Picnics')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Press Conferences')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Product Launches')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Recognition Dinners')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Religious Events')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Seasonal Events')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Seminars')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Shareholder Meetings')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Special Event Parties')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Sports')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Team Building Events')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Trade Fairs')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Trade Shows')");            
            Sql("INSERT INTO EventTypes(Name) VALUES ('Weddings')");
            Sql("INSERT INTO EventTypes(Name) VALUES ('Others')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM EventTypes WHERE Id IN " +
                "(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, " +
                "15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29)");
        }
    }
}
