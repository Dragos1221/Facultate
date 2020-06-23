package ProjectRepository;





import ProjectModels.Destinatie;



import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public class DestinatieRepository {

    private JdbcUtils jdbc;


    public DestinatieRepository(JdbcUtils jdbc) {
        this.jdbc = jdbc;
    }

    public int getIdDestinatie(String destinatie , LocalDateTime data)
    {
        String query="SELECT idDestinatie,Destinatie.Data_Si_Ora From Destinatie Where Destinatie.Destinatie='" +destinatie+"'";
        Connection con = jdbc.getConnection();
        try(Statement stm = con.createStatement()) {
            try (ResultSet res = stm.executeQuery(query)) {
                    while(res.next())
                    {
                        if(res.getString("Data_Si_Ora").equals(data.toString()))
                        {
                            return res.getInt("idDestinatie");
                        }
                    }
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return -1;
    }


    public List<Destinatie> returnList()
    {
        List<Destinatie> list =new ArrayList<>();
        String query="SELECT * From Destinatie";
        Connection con = jdbc.getConnection();
        try(Statement stm = con.createStatement()) {
            try (ResultSet res = stm.executeQuery(query)) {
                while(res.next())
                {
                    int id= res.getInt("idDestinatie");
                    int disponibil = res.getInt("LocuriDisponibile");
                    int ocupate = res.getInt("LocuriOcupate");
                    String destinatie = res.getString("Destinatie");
                    String[] data=res.getString("Data_Si_Ora").split("T");
                    int an=Integer.parseInt(data[0].split("-")[0]);
                    int luna=Integer.parseInt(data[0].split("-")[1]);
                    int zi=Integer.parseInt(data[0].split("-")[2]);
                    int ora = Integer.parseInt(data[1].split(":")[0]);
                    int min = Integer.parseInt(data[1].split(":")[1]);
                    LocalDateTime time = LocalDateTime.of(an,luna,zi,ora,min);
                    list.add(new Destinatie(id,time,disponibil,ocupate,destinatie));
                }
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return list;
    }

    public Destinatie getDestinatie(int idDest)
    {
        String query="SELECT * From Destinatie Where Destinatie.idDestinatie="+idDest;
        Connection con = jdbc.getConnection();
        try(Statement stm = con.createStatement()) {
            try (ResultSet res = stm.executeQuery(query)) {
                while(res.next())
                {
                    int id= res.getInt("idDestinatie");
                    int disponibil = res.getInt("LocuriDisponibile");
                    int ocupate = res.getInt("LocuriOcupate");
                    String destinatie = res.getString("Destinatie");
                    String[] data=res.getString("Data_Si_Ora").split("T");
                    int an=Integer.parseInt(data[0].split("-")[0]);
                    int luna=Integer.parseInt(data[0].split("-")[1]);
                    int zi=Integer.parseInt(data[0].split("-")[2]);
                    int ora = Integer.parseInt(data[1].split(":")[0]);
                    int min = Integer.parseInt(data[1].split(":")[1]);
                    LocalDateTime time = LocalDateTime.of(an,luna,zi,ora,min);
                    return  new Destinatie(id,time,disponibil,ocupate,destinatie);

                }
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public void update(Destinatie dest)
    {
        String query="UPDATE Destinatie SET LocuriDisponibile="+dest.getLocuriDisponibile()+", LocuriOcupate="+dest.getLocuriOcupate()+" WHERE idDestinatie=" + dest.getId();
        Connection con = jdbc.getConnection();
        try(Statement stm = con.createStatement()) {
            stm.executeUpdate(query);
        } catch (SQLException e) {
            e.printStackTrace();
        }

    }
}
