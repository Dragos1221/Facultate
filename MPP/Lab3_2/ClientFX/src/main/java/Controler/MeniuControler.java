package Controler;


import Observer.IObserver;
import ProjectModels.Destinatie;
import ProjectModels.Rezervare;
import ServiceImplementation.ServiceDestinatie;
import ServiceImplementation.ServiceOficii;
import ServiceImplementation.ServiceRezervare;
import ServiceInterface.IServiceDestinatie;
import ServiceInterface.IServiceOficii;
import ServiceInterface.IServiceRezervare;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;

import java.time.LocalDateTime;
import java.util.List;

public class MeniuControler implements IObserver {
    private IServiceOficii offServ;
    private IServiceDestinatie destServ;
    private IServiceRezervare rezServ;
    private int id=-1;
    private int locuri=-1;
    @FXML Label info;
    @FXML TableView<Destinatie> table=new TableView<>();
    @FXML TableView<Rezervare> tabelPartial=new TableView<>();
    @FXML TextField destinatieTxt;
    @FXML TextField dataTxt;
    @FXML TextField numeTxt;
    @FXML TextField nrLocuriTxt;

    public void initialize()
    {


    }

    public void setData(IServiceOficii offServ, IServiceDestinatie destServ, IServiceRezervare rezServ) {
        this.offServ = offServ;
        this.destServ = destServ;
        this.rezServ = rezServ;
        setColumnsTable();
        incarcaDate();
    }

    @FXML
    public void cauta()
    {
        String destinatie = destinatieTxt.getText();
        String data=dataTxt.getText();
        String[] list = data.split(" ");
        int an=Integer.parseInt(list[0].split("-")[0]);
        int luna = Integer.parseInt(list[0].split("-")[1]);
        int zi = Integer.parseInt(list[0].split("-")[2]);
        int ora =Integer.parseInt(list[1].split(":")[0]);
        int minut=Integer.parseInt(list[1].split(":")[1]);
        LocalDateTime a=LocalDateTime.of(an,luna,zi,ora,minut);
        int id= destServ.getIdDestinatie(destinatie,a);
        for(Rezervare x:rezServ.getList(id))
        {
            tabelPartial.getItems().add(x);
        }
    }



    public void incarcaDate()
    {
        table.getItems().clear();
        List<Destinatie> l = destServ.returnLista();
        for(Destinatie x : l)
        {
            table.getItems().add(x);
        }

    }

    public void setColumnsTable()
    {
        TableColumn<Destinatie,String> idColumn=new TableColumn<>("id");
        TableColumn<Destinatie,String> lDisponibileColumn=new TableColumn<>("Disponibile");
        TableColumn<Destinatie,String> lOcupateColumn=new TableColumn<>("Ocupate");
        TableColumn<Destinatie,String> destColumn=new TableColumn<>("Destinatie");
        TableColumn<Destinatie,String> dataColumn=new TableColumn<>("Data");

        idColumn.setCellValueFactory(new PropertyValueFactory<Destinatie,String>("id"));
        lDisponibileColumn.setCellValueFactory(new PropertyValueFactory<Destinatie,String>("LocuriDisponibile"));
        lOcupateColumn.setCellValueFactory(new PropertyValueFactory<Destinatie,String>("LocuriOcupate"));
        destColumn.setCellValueFactory(new PropertyValueFactory<Destinatie,String>("Destinatie"));
        dataColumn.setCellValueFactory(new PropertyValueFactory<Destinatie,String>("local"));

        table.getColumns().addAll(idColumn,lDisponibileColumn,lOcupateColumn,destColumn,dataColumn);

        TableColumn<Rezervare,String> idDestinatieColumn=new TableColumn<>("idDestinatie");
        TableColumn<Rezervare,String> nrLocColumn=new TableColumn<>("Numar locuri");
        TableColumn<Rezervare,String> numeColumn=new TableColumn<>("Nume");

        idDestinatieColumn.setCellValueFactory(new PropertyValueFactory<Rezervare,String>("idDestinatie"));
        nrLocColumn.setCellValueFactory(new PropertyValueFactory<Rezervare,String>("Locuri_rezervate"));
        numeColumn.setCellValueFactory(new PropertyValueFactory<>("nume"));
        table.getSelectionModel().selectedItemProperty().addListener((observableValue, oldStudent, newStudent)->{
            if(newStudent == null)
                newStudent = oldStudent;
            id=newStudent.getId();
            locuri=newStudent.getLocuriDisponibile();
        });
        tabelPartial.getColumns().addAll(idDestinatieColumn,nrLocColumn,numeColumn);
    }


    @FXML
    public void rezervare()
    {
        int locuri=Integer.parseInt(nrLocuriTxt.getText());
        if(!(id==-1 || numeTxt.getText().equals("") && nrLocuriTxt.getText().equals("")))
        {
            if(Integer.parseInt(nrLocuriTxt.getText()) > this.locuri)
            {
                Alert alert = new Alert(Alert.AlertType.INFORMATION);
                alert.setTitle("Information Dialog");
                alert.setContentText("Insuficiente locuri!");
                alert.showAndWait();
                nrLocuriTxt.clear();
            }
            else {
                Destinatie dest = destServ.getDestinatie(id);
                dest.setLocuriDisponibile(dest.getLocuriDisponibile()-locuri);
                dest.setLocuriOcupate(dest.getLocuriOcupate()+locuri);
                destServ.update(dest);
                rezServ.save(new Rezervare(id, Integer.parseInt(nrLocuriTxt.getText()), numeTxt.getText()));
                id=-1;
            }
        }
    }

    public void incarcaDate2(List<Destinatie> l)
    {
        table.getItems().clear();
        for(Destinatie x : l)
        {
            table.getItems().add(x);
        }
    }

    public void logout(){
        offServ.closeConnection();
    }

    @Override
    public void reloList(List<Destinatie> l) {
        incarcaDate2(l);
    }
}
