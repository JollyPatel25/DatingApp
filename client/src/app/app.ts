import { HttpClient } from '@angular/common/http';
import { Component, inject, signal, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { Nav } from '../layout/nav/nav';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,Nav],
  templateUrl: './app.html',
  styleUrl: './app.css'
})


export class App implements OnInit {
  private http = inject(HttpClient);
  protected readonly title = "Dating App";
  protected members = signal<any>([]);

  async ngOnInit(){
    this.members.set(await this.getMembers());
  }
  async getMembers()
  {
    try {
      return lastValueFrom(this.http.get("https://localhost:5003/api/members"));
    } catch (error) {
      throw error;
    }
  }

}
