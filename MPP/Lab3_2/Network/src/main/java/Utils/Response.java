package Utils;

import ProjectModels.Destinatie;
import ProjectModels.Rezervare;

import java.io.Serializable;
import java.util.List;

public class Response implements Serializable {
    private List<Rezervare> list;
    private List<Destinatie> listDestinatii;
    private String Mesaj;
    private Boolean bol;
    private Destinatie destinatie;
    private int id;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public Destinatie getDestinatie() {
        return destinatie;
    }

    public void setDestinatie(Destinatie destinatie) {
        this.destinatie = destinatie;
    }

    public List<Destinatie> getListDestinatii() {
        return listDestinatii;
    }

    public void setListDestinatii(List<Destinatie> listDestinatii) {
        this.listDestinatii = listDestinatii;
    }

    public Response(String Mesaj) {
        this.Mesaj = Mesaj;
    }

    public String getMesaj() {
        return Mesaj;
    }

    public void setMesaj(String mesaj) {
        Mesaj = mesaj;
    }

    public Boolean getBol() {
        return bol;
    }

    public List<Rezervare> getList() {
        return list;
    }

    public void setList(List<Rezervare> list) {
        this.list = list;
    }

    public void setBol(Boolean bol) {
        this.bol = bol;
    }
}
