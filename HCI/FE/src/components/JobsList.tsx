import * as React from 'react';
import { Component } from 'react';

import { withStyles, Theme, createStyles, makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';

export interface JobsListProps {
    
}
 
export interface JobsListState {
    
}

const StyledTableCell = withStyles((theme: Theme) =>
  createStyles({
    head: {
      backgroundColor: theme.palette.common.black,
      color: theme.palette.common.white,
    },
    body: {
      fontSize: 14,
    },
  }),
)(TableCell);

const StyledTableRow = withStyles((theme: Theme) =>
  createStyles({
    root: {
      '&:nth-of-type(odd)': {
        backgroundColor: theme.palette.action.hover,
      },
    },
  }),
)(TableRow);


function createData(id: number, job: string) {
    return {id,job };
  }
  
  const rows = [
    createData(1,"Fermier"),
    createData(2,"Fermier"),
    createData(3,"Fermier"),
    createData(4,"Fermier"),
    createData(5,"Fermier"),
    createData(6,"Fermier"),
    createData(7,"Fermier"),
  ];
  
  const useStyles = makeStyles({
    table: {
      minWidth: 700,
    },
  });
 
class JobsList extends React.Component<JobsListProps, JobsListState> {
    render() { 
        return (
            <TableContainer component={Paper}>
                    <Table aria-label="customized table">
                        <TableHead>
                            <TableRow>
                                <StyledTableCell>Dessert (100g serving)</StyledTableCell>
                                <StyledTableCell align="right">Calories</StyledTableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                        {rows.map((row) => (
                            <StyledTableRow key={row.id}>
                            <StyledTableCell component="th" scope="row">
                                {row.id}
                            </StyledTableCell>
                            <StyledTableCell component="th" scope="row">
                                {row.job}
                            </StyledTableCell>
                            
                            </StyledTableRow>
                        ))}
                        </TableBody>
                    </Table>
            </TableContainer>
          );
    }
}
 
export default JobsList;