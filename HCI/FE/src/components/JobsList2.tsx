import * as React from 'react';
import { arrayMove, SortableContainer, SortableElement } from 'react-sortable-hoc';
import '../JobsList.css';



export interface JobListProps {
  items: any;
  updateListJobs: any;
  select:any;
  updateJob:any;
}

export interface JobListState {
  items:any;
}


class JobsList2 extends React.Component<JobListProps, JobListState> {



   SortableList = SortableContainer(({items}: {items: any[]}) => 
      <ul key={2} id={'ulList'}>
        {items.map((value :any, index:any) => {
          if (value != null)
            return <this.SortableItem key={value.id} index={value.id} value={value.name} id={value.id}/>;
        })}
      </ul>);

 SortableItem = SortableElement(({value, id}: {value: string, id: number}) =>
    <li key={id} onClick={(event:any)=>{
      this.loadCv(event.target.id);
    }}  id={''+id}  onDoubleClick={(event:any)=>{
     this.props.updateJob(event.target.id)
    }} value={value}>{value}</li>
  );

  loadCv = (c:any)=>{
    this.props.select(c);
  }

  updateJob = (id:any)=>{

  }

  private onSortEnd = ({oldIndex, newIndex}: {oldIndex: number, newIndex: number}) => {
      let data = this.props.items;
      console.log(oldIndex, newIndex , data);
      data = arrayMove(data, oldIndex, newIndex);
      console.log(data);
      this.props.updateListJobs(data);
  };

  render() {
    return (
    <div className={'container'}>
        <h2>Lista Posturi</h2>
        <this.SortableList items={this.props.items} onSortEnd={this.onSortEnd} distance={1} lockAxis="y"/>
    </div>
    )
  }
}

export default JobsList2;