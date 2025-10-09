import { HttpClient } from '@angular/common/http';
import { Component, inject, signal, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
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
      return lastValueFrom(this.http.get("http://localhost:5003/api/members"));
    } catch (error) {
      throw error;
    }
  }

}
