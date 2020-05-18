
import Controler.MeniuControler;
import ProjectRepository.DestinatieRepository;
import ProjectRepository.JdbcUtils;
import ProjectRepository.OfficeRepositoryHibernate;
import ProjectRepository.RezervareRepository;
import Proxy.DestinatieProxy;
import Proxy.OficiuProxy;
import Proxy.ReadResponse;
import Proxy.RezervareProxy;
import ServiceInterface.IServiceDestinatie;
import ServiceInterface.IServiceOficii;
import ServiceInterface.IServiceRezervare;
import javafx.application.Application;
import javafx.event.EventHandler;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;


import Controler.startControler;
import javafx.stage.WindowEvent;


import java.io.*;
import java.net.Socket;
import java.util.Properties;

public class MainFX extends Application {
    private DestinatieRepository destRep;
    private OfficeRepositoryHibernate offRep;
    private RezervareRepository rezRep;
    private startControler cont;
    private JdbcUtils jdbc;
    private IServiceOficii offServ;
    private IServiceDestinatie destServ;
    private IServiceRezervare rezServ;
    private ReadResponse r;

    private Socket connection;
    private ObjectInputStream input;
    private ObjectOutputStream output;

    private static int defaultChatPort = 55555;
    private static String defaultServer = "localhost";



    @Override
    public void start(Stage stage) throws Exception {

        connection=new Socket(defaultServer,defaultChatPort);
        try {
            output = new ObjectOutputStream(connection.getOutputStream());
            output.flush();
            input = new ObjectInputStream(connection.getInputStream());
        } catch (IOException e) {
            e.printStackTrace();
        }


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
        jdbc = new JdbcUtils(prop);
    }

    public void setData()
    {
        r=new ReadResponse(connection , output, input);
        r.startReader();
        offRep=new OfficeRepositoryHibernate(jdbc);
        rezRep=new RezervareRepository(jdbc);
        destRep=new DestinatieRepository(jdbc);
        destServ=new DestinatieProxy(input,output,connection,r);
        offServ=new OficiuProxy(connection,r, output , input);
        rezServ=new RezervareProxy(input,output,connection,r);
        r.setServOficii(offServ);

    }
}