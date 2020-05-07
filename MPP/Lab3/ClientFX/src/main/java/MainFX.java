import Interfete.IServiceDestinatie;
import Interfete.IServiceOficii;
import Interfete.IServiceRezervare;
import ProjectControler.MeniuControler;
import ProjectControler.startControler;
import ProjectRepository.DestinatieRepository;
import ProjectRepository.JdbcUtils;
import ProjectRepository.OfficeRepository;
import ProjectRepository.RezervareRepository;
import ProjectService.ObserverImpl;
import ProjectService.ServiceDestinatie;
import ProjectService.ServiceOficii;
import ProjectService.ServiceRezervare;
import ProxyClient.ProxiClientOficiu;
import ProxyClient.ProxiClientRezervare;
import ProxyClient.ProxyClientDestinatie;
import ProxyClient.ReadResponse;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;



import java.io.FileReader;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.time.LocalDateTime;
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
    private ReadResponse read;

    private static int defaultChatPort = 55555;
    private static String defaultServer = "localhost";

    private Socket connection;
    private ObjectInputStream input;
    private ObjectOutputStream output;


    @Override
    public void start(Stage stage) throws Exception {


        connection=new Socket(defaultServer,defaultChatPort);
        output=new ObjectOutputStream(connection.getOutputStream());
        output.flush();
        input=new ObjectInputStream(connection.getInputStream());

        setJDBC();
        setData();

        FXMLLoader loaderr = new FXMLLoader();
        loaderr.setLocation(getClass().getResource("start.fxml"));
        Parent root = loaderr.load();
        cont=loaderr.getController();
        stage.setScene(new Scene(root));
        stage.setTitle("My app");
        stage.show();
        cont.setStage(stage);
        cont.setData(offServ,destServ,rezServ);

        FXMLLoader loader2=new FXMLLoader();
        loader2.setLocation(getClass().getResource("meniu.fxml"));
        Parent root2=loader2.load();
        Stage stage2=new Stage();
        stage2.setScene(new Scene(root2));
        stage2.setTitle("asdas");
        cont.setStageMeniu(stage2);
        MeniuControler men = loader2.getController();
        men.setData(offServ,destServ,rezServ);



    }

    public static void main(String[] args) {
        launch(args);
    }

    public  void setJDBC(){
        Properties prop =new Properties();
        try {
            prop.load(new FileReader("baza.properties"));
            System.out.println("Properties set. ");
            prop.list(System.out);
        } catch (IOException e) {
            System.out.println("Cannot find bd.config "+e);
        }
        jdbc = new JdbcUtils(prop);
    }

    public void setData()
    {
        offRep=new OfficeRepository(jdbc);
        rezRep=new RezervareRepository(jdbc);
        destRep=new DestinatieRepository(jdbc);
        destServ=new ServiceDestinatie(destRep);
        read=new ReadResponse(defaultServer,defaultChatPort,input,output,connection,new ObserverImpl());
        offServ=new ProxiClientOficiu(defaultServer,defaultChatPort,input,output,connection ,read);
        rezServ=new ServiceRezervare(rezRep);
    }


}