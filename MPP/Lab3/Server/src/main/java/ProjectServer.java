import Interfete.IServiceDestinatie;
import Interfete.IServiceOficii;
import Interfete.IServiceRezervare;
import ProjectRepository.DestinatieRepository;
import ProjectRepository.JdbcUtils;
import ProjectRepository.OfficeRepository;
import ProjectRepository.RezervareRepository;
import ProjectService.ServiceDestinatie;
import ProjectService.ServiceOficii;
import ProjectService.ServiceRezervare;
import Protocol.ConcurentServer;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.rmi.ServerException;
import java.util.Properties;

public class ProjectServer {
    private JdbcUtils jdbc;
    private static int defaultPort=55555;

    public static void main(String[] args)  {
        int chatServerPort=defaultPort;
        Properties prop = new Properties();
        try{
            prop.load(new FileInputStream("C:\\Users\\Dragos\\Desktop\\FacultateInfo\\MPP\\Lab3\\Server\\baza.properties"));
            prop.list(System.out);
        } catch (FileNotFoundException e) {
            System.out.println(e.getMessage());
        } catch (IOException e) {
            e.printStackTrace();
        }
        JdbcUtils jdbc = new JdbcUtils(prop);

        RezervareRepository repRez = new RezervareRepository(jdbc);
        IServiceRezervare servRez=new ServiceRezervare(repRez);

        DestinatieRepository repdest = new DestinatieRepository(jdbc);
        IServiceDestinatie servDest = new ServiceDestinatie(repdest);

        OfficeRepository rep = new OfficeRepository(jdbc);
        IServiceOficii serv = new ServiceOficii(rep);
        ConcurentServer server = new ConcurentServer(chatServerPort,serv,servRez,servDest);


        try
        {
            server.start();
        } catch (ServerException e) {
            System.err.println("Eroare pornire server: "+e.getMessage() );
        }finally {
            server.stop();
        }
    }
}
