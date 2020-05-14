package Protocol;

import Observer.IObserver;
import ProjectModels.Destinatie;
import ProjectModels.Oficiu;
import ProjectModels.Rezervare;
import ServiceInterface.IServiceDestinatie;
import ServiceInterface.IServiceOficii;
import ServiceInterface.IServiceRezervare;
import Utils.Request;
import Utils.Response;
import jdk.nashorn.internal.runtime.ListAdapter;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public class Worker implements Runnable , IObserver {
    private IServiceOficii servOficii;
    private IServiceRezervare servRezervare;
    private IServiceDestinatie servDestinatie;
    private Socket connection;
    private ObjectInputStream input;
    private ObjectOutputStream output;
    private volatile boolean connected;

    public Worker(IServiceOficii servOficii, IServiceRezervare servRezervare, IServiceDestinatie servDestinatie, Socket connection) {
        this.servOficii = servOficii;
        this.servRezervare = servRezervare;
        this.servDestinatie = servDestinatie;
        this.connection = connection;
        this.connection = connection;
        try{
            output=new ObjectOutputStream(connection.getOutputStream());
            output.flush();
            input= new ObjectInputStream(connection.getInputStream());
            connected=true;
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void run() {
        while(connected) {
            try {
                Object cerere = input.readObject();
                raspunde((Request) cerere);
            } catch (IOException | ClassNotFoundException e) {
                e.printStackTrace();
                System.out.println(e.getMessage());
            }
        }
        try {
            input.close();
            output.close();
            connection.close();
        } catch (IOException e) {
            System.out.println("Error "+e);
        }
    }

    public void raspunde(Request c)
    {
        switch (c.getMesaj())
        {
            case "Login":
                login(c);
                break;
            case "Save":
                save(c);
                break;
            case "GetListaRezervari":
                getListaRezervari(c);
                break;
            case "getIdDestinatie":
               getIdDestinatie(c);
                break;
            case "getListDestinatii":
                getListDestinatii(c);
                break;
            case "getDestinatie":
                getDestinatie(c);
                break;
            case "Update":
                update(c);
                break;
            case "logout":
                logout();
                break;

        }
    }

    public void login(Request c)
    {
        Boolean bol = servOficii.logIn(c.getUser(),this);
        Response response = new Response("ok");
        response.setBol(bol);
        try {
            output.writeObject(response);
            output.flush();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void getListaRezervari(Request c)
    {
        int id = c.getId();
        List<Rezervare> l = servRezervare.getList(id);
        Response re = new Response("ok");
        re.setList(l);
        try {
            output.writeObject(re);
            output.flush();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void save(Request c)
    {
        Boolean bol = servRezervare.save(c.getRezervare());
        Response re = new Response("ok");
        re.setBol(bol);
        try{
            output.writeObject(re);
            output.flush();
        } catch (IOException e) {
            e.printStackTrace();
        }
        servOficii.notifyClients(servDestinatie.returnLista());
    }

    public void getListDestinatii(Request c)
    {
        List<Destinatie> l = new ArrayList<>();
        l=servDestinatie.returnLista();
        Response re = new Response("ok");
        re.setListDestinatii(l);
        try{
            output.writeObject(re);
            output.flush();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
    public void getDestinatie(Request c)
    {
        int id = c.getId();
        Destinatie dest = servDestinatie.getDestinatie(id);
        Response resp = new Response("ok");
        resp.setDestinatie(dest);
        try{
            output.writeObject(resp);
            output.flush();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void update(Request c)
    {
        List<Destinatie> l = new ArrayList<>();
        Destinatie dest = c.getDestinatie();
        servDestinatie.update(dest);
    }

    public void getIdDestinatie(Request c)
    {
        String destinatie = c.getDestinatieStr();
        String[] list = c.getLocalDateTime().split("T");

        int an = Integer.parseInt(list[0].split("-")[0]);
        int luna = Integer.parseInt(list[0].split("-")[1]);
        int zi = Integer.parseInt(list[0].split("-")[2]);
        int ora = Integer.parseInt(list[1].split(":")[0]);
        int minut = Integer.parseInt(list[1].split(":")[1]);
        LocalDateTime a = LocalDateTime.of(an, luna, zi, ora, minut);

        int id = servDestinatie.getIdDestinatie(destinatie,a);
        Response resp = new Response("ok");
        resp.setId(id);
        try {
            output.writeObject(resp);
            output.flush();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void reloList(List<Destinatie> l) {
       Response res = new Response("Observer");
       res.setListDestinatii(l);
       try{
           output.writeObject(res);
           output.flush();
       } catch (IOException e) {
           e.printStackTrace();
       }
    }

    public void logout()
    {
        connected=false;
    }


}
