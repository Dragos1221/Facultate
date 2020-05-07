package Protocol;

import Interfete.IServiceDestinatie;
import Interfete.IServiceOficii;
import Interfete.IServiceRezervare;
import Utils.AbsConcurentServer;

import java.net.Socket;

public class ConcurentServer extends AbsConcurentServer {
    private IServiceOficii servOficii;
    private IServiceRezervare servRez;
    private IServiceDestinatie servDest;


    public ConcurentServer(int port , IServiceOficii oficii , IServiceRezervare rez , IServiceDestinatie dest) {
        super(port);
        servDest=dest;
        servOficii=oficii;
        servRez=rez;
    }

    @Override
    protected Thread createWorker(Socket client) {
        ClientWorker worker  = new ClientWorker(client,servOficii,servRez ,servDest);
        Thread tw = new Thread(worker);
        return tw;
    }

    @Override
    public void stop()

    {
        System.out.println("Stopping services ...");
    }

}
