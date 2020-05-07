package ProjectControler;


import Interfete.IServiceDestinatie;
import Interfete.IServiceOficii;
import Interfete.IServiceRezervare;
import ProjectModel.Oficiu;
import ProjectService.ServiceDestinatie;
import ProjectService.ServiceOficii;
import ProjectService.ServiceRezervare;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.stage.Stage;
import java.io.IOException;

public class startControler {
    private IServiceOficii offServ;
    private IServiceDestinatie destServ;
    private IServiceRezervare rezServ;
    private Stage stageLogin;
    private Stage stageMeniu;
    @FXML TextField userTxt;
    @FXML PasswordField passwTxt;


    public void setStage(Stage st)
    {
        stageLogin=st;
    }
    public void setStageMeniu(Stage st)
    {
        stageMeniu=st;
    }

    public void initializa()
    {

    }

    public void setData(IServiceOficii offServ, IServiceDestinatie destServ, IServiceRezervare rezServ ) {
        this.offServ = offServ;
        this.destServ = destServ;
        this.rezServ = rezServ;
    }

    @FXML
    public void act(){
        String user=userTxt.getText();
        String pass=passwTxt.getText();
        Oficiu of = new Oficiu(user,pass);
        if(offServ.logIn(of))
        {
            stageLogin.hide();
            stageMeniu.show();
        }
        else
        {
            passwTxt.clear();
        }
    }
}
