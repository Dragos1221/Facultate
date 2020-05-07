package Utils;

import java.io.Serializable;

public class Cerere implements Serializable {
    String mesaj;
    private Boolean bol;

    public Boolean getBol() {
        return bol;
    }

    public void setBol(Boolean bol) {
        this.bol = bol;
    }

    public Cerere(String mesaj) {
        this.mesaj = mesaj;
    }

    public String getMesaj() {
        return mesaj;
    }

    public void setMesaj(String mesaj) {
        this.mesaj = mesaj;
    }

    @Override
    public String toString() {
        return "Cerere{" +
                "mesaj='" + mesaj + '\'' +
                '}';
    }
}
