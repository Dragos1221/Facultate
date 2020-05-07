import Controler.MeniuControler;
import Controler.startControler;
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
import javafx.application.Application;
import javafx.event.EventHandler;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import javafx.stage.WindowEvent;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

import java.io.FileInputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.util.Properties;

public class MainFX extends Application {
    private DestinatieRepository destRep;
    private OfficeRepository offRep;
    private RezervareRepository rezRep;
    private startControler cont;
    private JdbcUtils jdbc;
    private IServiceOficii offServ;
    private IServiceDestinatie destServ;
    private IServiceRezervare rezServ;


    private Socket connection;
    private ObjectInputStream input;
    private ObjectOutputStream output;

    private static int defaultChatPort = 55555;
    private static String defaultServer = "localhost";



    @Override
    public void start(Stage stage) throws Exception {



        FXMLLoader loaderr = new FXMLLoader();
        loaderr.setLocation(getClass().getResource("start.fxml"));
        Parent root = loaderr.load();
        cont=loaderr.getController();
        stage.setScene(new Scene(root));
        stage.setTitle("My app");
        stage.show();
        cont.setStage(stage);
        setJDBC();
        setData();
        cont.setData(offServ,destServ,rezServ);

        FXMLLoader loader2=new FXMLLoader();
        loader2.setLocation(getClass().getResource("meniu.fxml"));
        Parent root2=loader2.load();
        Stage stage2=new Stage();
        stage2.setScene(new Scene(root2));
        stage2.setTitle("asdas");
        MeniuControler men = loader2.getController();
        stage2.setOnCloseRequest(new EventHandler<WindowEvent>() {
            public void handle(WindowEvent we) {
                men.logout();
            }});
        men.setData(offServ,destServ,rezServ);
        cont.setStageMeniu(stage2 ,men);

        /*FXMLLoader[] loaders3 = new FXMLLoader[20];
        Parent[] root3=new Parent[20];
        Stage[] stage3=new Stage[20];

        FXMLLoader[] loaders33 = new FXMLLoader[20];
        Parent[] root33=new Parent[20];
        Stage[] stage33=new Stage[20];

        MeniuControler[] meniuCont=new MeniuControler[20];
        startControler[] startCont=new startControler[20];
        for(int i=0;i<=3;++i){
            loaders3[i]=new FXMLLoader();
            loaders3[i].setLocation(getClass().getResource("start.fxml"));
            root3[i]=loaders3[i].load();
            startCont[i]=loaders3[i].getController();
            stage3[i]=new Stage();
            stage3[i].setScene(new Scene(root3[i]));
            stage3[i].show();
            startCont[i].setStage(stage3[i]);
            startCont[i].setData(offServ,destServ,rezServ,obsServ);

            loaders33[i]=new FXMLLoader();
            loaders33[i].setLocation(getClass().getResource("meniu.fxml"));
            root33[i]=loaders33[i].load();
             stage33[i]=new Stage();
            stage33[i].setScene(new Scene(root33[i]));
            stage33[i].setTitle("asdas");
            startCont[i].setStageMeniu(stage33[i]);
            meniuCont[i] = loaders33[i].getController();
            meniuCont[i].setData(offServ,destServ,rezServ,obsServ);



        }

         */
    }

    public static void main(String[] args) {
        launch(args);
    }

    public  void setJDBC(){
        Properties prop =new Properties();
        try {
            prop.load(new FileInputStream("C:\\Users\\Dragos\\Desktop\\FacultateInfo\\MPP\\Lab3_2\\ClientFX\\src\\main\\resources\\baza.properties"));
            System.out.println("Properties set. ");
            prop.list(System.out);
        } catch (IOException e) {
            System.out.println("Cannot find bd.config "+e);
        }
        jdbc = new JdbcUtils();
    }

    public void setData()
    {
        ApplicationContext factory = new ClassPathXmlApplicationContext("classpath:cliebtProp.xml");

        offRep=new OfficeRepository(jdbc);
        rezRep=new RezervareRepository(jdbc);
        destRep=new DestinatieRepository(jdbc);
        destServ=new ServiceDestinatie(destRep);
        rezServ=new ServiceRezervare(rezRep);
        offServ = (IServiceOficii) factory.getBean("offServ");

    }
}