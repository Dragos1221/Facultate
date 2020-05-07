package Controler;


import ProjectModels.Oficiu;
import ServiceInterface.IServiceDestinatie;
import ServiceInterface.IServiceOficii;
import ServiceInterface.IServiceRezervare;
import javafx.fxml.FXML;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

import java.rmi.RemoteException;

public class startControler {
    private IServiceOficii offServ;
    private IServiceDestinatie destServ;
    private IServiceRezervare rezServ;
    private Stage stageLogin;
    private Stage stageMeniu;
    private MeniuControler contr;
    @FXML TextField userTxt;
    @FXML PasswordField passwTxt;


    public void setStage(Stage st)
    {
        stageLogin=st;
    }
    public void setStageMeniu(Stage st , MeniuControler men)
    {
        stageMeniu=st;
        contr=men;
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
        try {
            if (offServ.logIn(of)) {
                stageLogin.close();
                stageMeniu.show();
            } else {
                passwTxt.clear();
            }
        } catch (RemoteException e) {
            e.printStackTrace();
        }
    }
}
