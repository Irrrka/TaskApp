import { EmployeeExperienceLevel } from './EmployeeExperienceLevev'

export interface Employee {
    firstName : string,
    lastName: string,
    startingDate: Date,
    salary: Number,
    vacationDays: Number,
    experienceLevel: EmployeeExperienceLevel
}