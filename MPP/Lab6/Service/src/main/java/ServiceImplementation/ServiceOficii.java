package ServiceImplementation;


import Observer.IObserver;
import ProjectModels.Destinatie;
import ProjectModels.Oficiu;
import ProjectRepository.OfficeRepository;
import ServiceInterface.IServiceOficii;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class ServiceOficii implements IServiceOficii {
    private OfficeRepository rep;
    private List<IObserver> list;

    public ServiceOficii(OfficeRepository rep) {
        this.rep = rep;
        list=new ArrayList<>();
    }

    public synchronized boolean logIn(Oficiu of , IObserver obs){
        list.add(obs);
        return rep.logIn(of);
    }

    @Override
    public void closeConnection() { };


    private final int defaultThreadsNo=5;
    public  void notifyClients(List<Destinatie> l)
    {
        ExecutorService executor= Executors.newFixedThreadPool(defaultThreadsNo);
        for(IObserver o : list)
        {
            executor.execute(() -> {
                try{
                    o.reloList(l);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            });
        }
    }
}
