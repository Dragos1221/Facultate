package ServerProject;

import ProjectRepository.DestinatieRepository;
import ProjectRepository.JdbcUtils;
import ProjectRepository.OfficeRepository;
import ProjectRepository.RezervareRepository;
import Protocol.ConcurentServer;
import ServiceImplementation.ServiceDestinatie;
import ServiceImplementation.ServiceOficii;
import ServiceImplementation.ServiceRezervare;
import ServiceInterface.IServiceDestinatie;
import ServiceInterface.IServiceOficii;
import ServiceInterface.IServiceRezervare;

import java.io.FileInputStream;
import java.io.IOException;
import java.rmi.ServerException;
import java.util.Properties;

public class Server {

    private static int defaultPort=55555;

    public static void main(String[] args) {
        int chatServerPort=defaultPort;
        Properties prop =new Properties();
        try {
            prop.load(new FileInputStream("C:\\Users\\Dragos\\Desktop\\FacultateInfo\\MPP\\Lab3_2\\ClientFX\\src\\main\\resources\\baza.properties"));
            System.out.println("Properties set. ");
            prop.list(System.out);
        } catch (IOException e) {
            System.out.println("Cannot find bd.config "+e);
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
