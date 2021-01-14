import * as React from 'react';
import { arrayMove, SortableContainer, SortableElement } from 'react-sortable-hoc';
import '../JobsList.css';

export interface CvListProps {
  items: any;
  selectCv:any;
  
}

export interface CVListState {
  items:any;
}

class JobsList2 extends React.Component<CvListProps, CVListState> {


 SortableList = SortableContainer(({items}: {items: any[]}) => 
  <ul key={2} id={'ulList'}>
    {items.map((value :any, index:any) => {
      if (value != null)
        return <this.SortableItem key={value.id} index={value.id} value={value.name} id={value.id} order={index+1}/>;
    })}
  </ul>);
  
   SortableItem = SortableElement(({value, id , order}: {value: string, id: number , order:number}) =>
    <li key={id} onDoubleClick={(e:any)=>{
        this.props.selectCv(e.target.id);
      }
    } id={''+id} value={value}> <span>{order}</span>{value}</li>
  );

  private onSortEnd = ({oldIndex, newIndex}: {oldIndex: number, newIndex: number}) => {
    if(oldIndex !== newIndex)
    {
      let data = this.props.items;
      data = arrayMove(data, oldIndex, newIndex);
    }
  };
  render() {
    return (
    <div className={'container'}>
        <h2>Lista Cv-uri</h2>
        <this.SortableList items={this.props.items} onSortEnd={this.onSortEnd} distance={1} lockAxis="y"/>
    </div>
    )
  }
}

export default JobsList2;