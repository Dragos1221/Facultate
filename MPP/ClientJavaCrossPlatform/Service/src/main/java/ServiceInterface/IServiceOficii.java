package ServiceInterface;


import Observer.IObserver;
import ProjectModels.Destinatie;
import ProjectModels.Oficiu;

import java.util.List;

public interface IServiceOficii {
    public boolean logIn(Oficiu of, IObserver client);
    public void closeConnection();
    void notifyClients(List<Destinatie> l);
}
