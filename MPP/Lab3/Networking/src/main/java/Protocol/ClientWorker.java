package Protocol;

import Interfete.IServiceDestinatie;
import Interfete.IServiceOficii;
import Interfete.IServiceRezervare;
import ProjectModel.Destinatie;
import ProjectModel.Oficiu;
import ProjectModel.Rezervare;
import Utils.Cerere;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.time.LocalDateTime;
import java.util.List;

public class ClientWorker implements Runnable{
    private IServiceOficii servOficii;
    private IServiceRezervare servRezervare;
    private IServiceDestinatie servDestinatie;
    private Socket connection;
    private ObjectInputStream input;
    private ObjectOutputStream output;
    private volatile boolean connected;

    public ClientWorker(Socket connection , IServiceOficii oficii , IServiceRezervare rez ,IServiceDestinatie dest) {
        servDestinatie=dest;
        servOficii=oficii;
        servRezervare=rez;
        this.connection = connection;
        try{
            output=new ObjectOutputStream(connection.getOutputStream());
            output.flush();
            input=new ObjectInputStream(connection.getInputStream());
            connected=true;
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void run() {
        while(connected) {
            try {
                Object numar = input.readObject();
                raspunde((Cerere)numar);
            } catch (IOException | ClassNotFoundException e) {
                e.printStackTrace();
                System.out.println(e.getMessage());
            }
        }
    }

    public void raspunde(Cerere c)
    {

        switch (c.getMesaj())
        {
            case "Login":
                login();
                break;
            case "Save":
                save();
                break;
            case "GetListaRezervari":
                getListaRezervari();
                break;
            case "getIdDestinatie":
                getIdDestinatie();
                break;
            case "getListDestinatii":
               getListDestinatii();
                break;
            case "getDestinatie":
                getDestinatie();
                break;
            case "Update":
                Update();
                break;


        }
    }


    public void login(){
        try {
            Object user = input.readObject();
            Oficiu of = (Oficiu) user;
            Boolean bol = servOficii.logIn(of);
            Cerere cer = new Cerere("Ok");
            cer.setBol(bol);
           if(bol)
           {
               output.writeObject(cer);
               output.flush();
           }
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }

    public void save()
    {
        try{
            Object rez= input.readObject();
            Rezervare rezervare = (Rezervare)rez;
            output.writeBoolean(servRezervare.save(rezervare));
            output.flush();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }


    public void getListaRezervari(){
        int id=-1;
        try {
            id = input.readInt();
        } catch (IOException e) {
            e.printStackTrace();
        }
        try {
            List<Rezervare> list = servRezervare.getList(id);
            output.writeInt(list.size());
            output.flush();
            for (Rezervare r :list) {
                    output.writeObject(r);
                    output.flush();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void getIdDestinatie(){
        try {

            String destinatie = input.readUTF();
            String data = input.readUTF();
            String[] list = data.split("T");

            int an = Integer.parseInt(list[0].split("-")[0]);
            int luna = Integer.parseInt(list[0].split("-")[1]);
            int zi = Integer.parseInt(list[0].split("-")[2]);
            int ora = Integer.parseInt(list[1].split(":")[0]);
            int minut = Integer.parseInt(list[1].split(":")[1]);
            LocalDateTime a = LocalDateTime.of(an, luna, zi, ora, minut);
            output.writeInt(servDestinatie.getIdDestinatie(destinatie,a));
            output.flush();

        } catch (IOException e) {
            e.printStackTrace();
        }

    }

    public void getListDestinatii(){
        List<Destinatie> list = servDestinatie.returnLista();
        try{
            output.writeInt(list.size());
            output.flush();
            for(Destinatie x:list)
            {
                output.writeObject(x);
                output.flush();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void getDestinatie()
    {
        try {
            int id = input.readInt();
            Destinatie dest = servDestinatie.getDestinatie(id);
            if(dest != null)
            {
                output.writeObject(dest);
                output.flush();
            }
            else
            {
                output.writeObject(null);
                output.flush();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void Update()
    {
        try{
            Object obj = input.readObject();
            servDestinatie.update((Destinatie)obj);
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }

}