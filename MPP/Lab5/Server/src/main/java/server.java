import ProjectModels.Oficiu;
import ProjectRepository.DestinatieRepository;
import ProjectRepository.JdbcUtils;
import ProjectRepository.OfficeRepository;
import ProjectRepository.RezervareRepository;
import ServiceImplementation.ServiceDestinatie;
import ServiceImplementation.ServiceOficii;
import ServiceImplementation.ServiceRezervare;
import ServiceInterface.IServiceDestinatie;
import ServiceInterface.IServiceOficii;
import ServiceInterface.IServiceRezervare;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import java.io.FileInputStream;
import java.io.IOException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.rmi.server.UnicastRemoteObject;
import java.util.Properties;

public class server {

    public static void main(String[] args) {


        JdbcUtils jdbc = new JdbcUtils();

        ApplicationContext factory = new ClassPathXmlApplicationContext("classpath:serverProp.xml");




    }




}
