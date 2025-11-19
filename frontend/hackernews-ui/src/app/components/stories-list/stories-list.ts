import { Component, ChangeDetectorRef } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatCardModule } from '@angular/material/card';
import { MatPaginatorModule } from '@angular/material/paginator';
import { StoriesService, Story } from '../../services/stories';
import { finalize } from 'rxjs';

@Component({
  selector: 'app-stories-list',
  templateUrl: './stories-list.html',
  styleUrl: './stories-list.scss',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    MatInputModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    MatCardModule,
    MatPaginatorModule
  ],
})
export class StoriesList {
  stories: Story[] = [];
  page = 1;
  pageSize = 20;
  search = '';
  loading = false;

  constructor(private storiesService: StoriesService, private cdr: ChangeDetectorRef) {
    this.loadStories();
  }

  loadStories() {
    this.loading = true;
    this.storiesService.getStories(this.page, this.pageSize, this.search)
      .pipe(finalize(() => {
        this.loading = false;
        this.cdr.markForCheck();
      }))
      .subscribe({
        next: (data) => {
          console.log('Stories received:', data);
          this.stories = data;
        },
        error: (err) => {
          console.error('Error loading stories:', err);
          this.stories = [];
        }
      });
  }

  onSearchChange(event: any) {
    this.page = 1;
    this.loadStories();
  }

  nextPage() {
    this.page++;
    this.loadStories();
  }

  prevPage() {
    if (this.page > 1) {
      this.page--;
      this.loadStories();
    }
  }
}
