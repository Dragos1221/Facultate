package ServiceInterface;


import Observer.IObserver;
import ProjectModels.Destinatie;
import ProjectModels.Oficiu;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.List;

public interface IServiceOficii extends Remote {
    public boolean logIn(Oficiu of) throws RemoteException;
    public void closeConnection() throws RemoteException;
    void notifyClients(List<Destinatie> l) throws RemoteException;
}
