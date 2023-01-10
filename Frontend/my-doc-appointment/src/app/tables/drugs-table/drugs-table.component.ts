import { Component, OnInit } from '@angular/core';
import { Drug, NewDrug } from 'src/app/models/drug.model';
import { DrugsService } from 'src/app/services/drugs/drugs.service';

@Component({
  selector: 'drugs-table',
  templateUrl: './drugs-table.component.html',
  styleUrls: ['./drugs-table.component.scss']
})
export class DrugsTableComponent implements OnInit {
  
  showEditMenu: boolean = false;
  showCreateMenu: boolean = false;
  drugList: Drug[];

  newDrug: NewDrug = new NewDrug();
  currentDrug: Drug;
  updatedDrug: Drug;

  constructor(private drugService: DrugsService){
  }

  ngOnInit(): void {
    this.loadTable();
  }

  loadTable(){
    this.drugService.getAll().subscribe((drugs)=>{
      this.drugList = drugs;
    })
  }

  openEditMenu(drug: Drug){
    this.showEditMenu = true;
    this.currentDrug = new Drug(drug);
    this.updatedDrug = new Drug(drug);
    console.log(this.currentDrug);
  }

  closeEditMenu(){
    this.showEditMenu = false;
  }

  openCreateMenu(){
    this.showCreateMenu = true;
    this.newDrug = new NewDrug();
  }

  closeCreateMenu(){
    this.showCreateMenu = false;
  }

  clickedWhiteSpace(event : Event){
    const className = (event.target as Element).className;
    if(className === 'sidebar-menu'){
      this.closeEditMenu();
    }
  }

  createDrug(){
    this.closeCreateMenu();
    this.drugService.create(this.newDrug).subscribe((res)=>{
      this.loadTable();
    });
  }

  updateDrug(){
    this.closeEditMenu();
    this.drugService.update(this.currentDrug.id, this.updatedDrug).subscribe((res)=>{
      this.loadTable();
    })
  }

  deleteDrug(){
    this.closeEditMenu();
    this.drugService.delete(this.currentDrug.id).subscribe((res)=>{
      this.loadTable();
    })
  }
}
