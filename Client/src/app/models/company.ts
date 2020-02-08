import { Employee } from './employee';
import { Office } from './office';

export interface Company {
    id : number,
    name: string,
    creationDate: Date,
    employees: Employee[],
    offices: Office[]
}