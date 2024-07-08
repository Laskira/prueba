import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { UserService } from './services/user.service';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit  {
  title = 'front';

  displayedColumns: string[] = ['correo', 'nombre', 'apellido', 'genero'];

  users = []


  dataSource = new MatTableDataSource([]);

  constructor(private userService: UserService){

  }

  ngOnInit(): void {
    this.getData()
  }

  async getData(){
   const data = await firstValueFrom(this.userService.getUsers())
    return data
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
