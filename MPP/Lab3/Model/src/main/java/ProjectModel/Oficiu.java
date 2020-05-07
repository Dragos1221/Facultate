package ProjectModel;

import java.io.Serializable;

public class Oficiu implements Serializable {
    private String usarname;
    private String password;

    public Oficiu(String usarname, String password) {
        this.usarname = usarname;
        this.password = password;
    }

    public String getUsarname() {
        return usarname;
    }

    public void setUsarname(String usarname) {
        this.usarname = usarname;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    @Override
    public String toString() {
        return "Oficiu{" +
                "usarname='" + usarname + '\'' +
                ", password='" + password + '\'' +
                '}';
    }
}
