import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrl: './about.component.css'
})
export class AboutComponent implements OnInit{

  constructor(private route: ActivatedRoute , private router: Router) {}

  ngOnInit(): void {
    // Fragment değişikliklerini dinler
    this.route.fragment.subscribe(fragment => {
      if (fragment) {
        this.goToFragment(fragment);
      }
    });
  }

  goToFragment(fragmentId: string) {
    // Önce null fragment ile yönlendir, ardından hedef fragmente kaydır
    this.router.navigate([], { fragment: undefined, replaceUrl: true }).then(() => {
      setTimeout(() => {
        const element = document.getElementById(fragmentId);
        if (element) {
          element.scrollIntoView({ behavior: 'smooth', block: 'start' });
        }
      }, 0);
    });
  }

}
