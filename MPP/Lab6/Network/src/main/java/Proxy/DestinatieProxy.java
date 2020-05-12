package Proxy;

import ProjectModels.Destinatie;
import ServiceInterface.IServiceDestinatie;
import Utils.Request;
import Utils.Response;
import jdk.vm.ci.meta.Local;
import proto.ProjectProto;

import java.io.IOException;

import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public class DestinatieProxy implements IServiceDestinatie {
    private InputStream input;
    private OutputStream output;
    private Socket connection;
    private ReadResponse r;

    public DestinatieProxy(InputStream input, OutputStream output, Socket connection, ReadResponse r) {
        this.input = input;
        this.output = output;
        this.connection = connection;
        this.r = r;
    }

    @Override
    public int getIdDestinatie(String destinatie, LocalDateTime data) {
       // Request req = new Request("getIdDestinatie");
        //System.out.println(data.toString());

        ProjectProto.Request req = ProjectProto.Request.newBuilder().setDestinatieStr(destinatie).setMess("getIdDestinatie")
                .setAn(data.getYear()).setLuna(data.getMonthValue()).setZi(data.getDayOfMonth())
                .setOra(data.getHour()).setMinute(data.getMinute()).build();
       // req.setDestinatieStr(destinatie);
        //req.setLocalDateTime(data.toString());
        try{
            req.writeDelimitedTo(output);
            output.flush();
           ProjectProto.Response resp = r.readResponse();
            if(resp.getMess().equals("ok"))
            {
                return resp.getId();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return 0;
    }

    @Override
    public List<Destinatie> returnLista() {
        //Request cer = new Request("getListDestinatii");
        ProjectProto.Request cer = ProjectProto.Request.newBuilder().setMess("getListDestinatii").build();
        try{
            cer.writeDelimitedTo(output);
            output.flush();
            ProjectProto.Response re = r.readResponse();
            if(re.getMess().equals("ok"))
            {
                List<Destinatie> list = new ArrayList<>();
                for(int i=1;i<re.getListaDestinatiiCount();++i)
                {
                    LocalDateTime t = LocalDateTime.of(re.getListaDestinatii(i).getAn(),re.getListaDestinatii(i).getLuna(),
                            re.getListaDestinatii(i).getZi(),re.getListaDestinatii(i).getOra(),re.getListaDestinatii(i).getMinute());
                    list.add(new Destinatie(re.getListaDestinatii(i).getId(),t,re.getListaDestinatii(i).getLocuriDisponibile(),
                            re.getListaDestinatii(i).getLocuriOcupate(),re.getListaDestinatii(i).getDestinatie()));
                }
                return list;
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public Destinatie getDestinatie(int id) {
        //Request c = new Request("getDestinatie");
        ProjectProto.Request c = ProjectProto.Request.newBuilder().setMess("getDestinatie").setId(id).build();
       // c.setId(id);
        try{
            c.writeDelimitedTo(output);
            output.flush();
            ProjectProto.Response res=r.readResponse();
            if(res.getMess().equals("ok"))
            {
                ProjectProto.Destinatie d = res.getListaDestinatii(0);
                LocalDateTime t = LocalDateTime.of(d.getAn(),d.getLuna(),d.getZi(),d.getOra(),d.getMinute());
                return new Destinatie(d.getId(),t,d.getLocuriDisponibile(),d.getLocuriOcupate(),d.getDestinatie());
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public void update(Destinatie dest) {
      //  Request request = new Request("Update");
       // request.setDestinatie(dest);
        ProjectProto.Destinatie d = ProjectProto.Destinatie.newBuilder().setId(dest.getId())
                .setAn(dest.getLocal().getHour()).setLuna(dest.getLocal().getMonthValue())
                .setZi(dest.getLocal().getDayOfMonth()).setOra(dest.getLocal().getHour())
                .setMinute(dest.getLocal().getMinute()).setLocuriDisponibile(dest.getLocuriDisponibile())
                .setLocuriOcupate(dest.getLocuriOcupate()).setDestinatie(dest.getDestinatie()).build();

        ProjectProto.Request request = ProjectProto.Request.newBuilder().setMess("Update").setDestObj(d).build();
        try{
            request.writeDelimitedTo(output);
            output.flush();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
