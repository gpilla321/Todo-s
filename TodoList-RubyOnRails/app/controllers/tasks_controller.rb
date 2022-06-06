class TasksController < ApplicationController
  TASKS_PER_PAGE = 5
  
  
  def index
    @page = params[:page].nil? ? 1 : params[:page].to_i - 1
    @actual_page = @page

    @tasks = Task.all.offset(@page * TASKS_PER_PAGE).limit(TASKS_PER_PAGE)
    @totalPages = (Task.all.count / TASKS_PER_PAGE).to_i + 1
    
    @prev_page = @actual_page > 1 ? @actual_page - 1 : 1
    @next_page = @actual_page < @totalPages ? @actual_page + 2 : @totalPages
    @show_next = @next_page <= @totalPages
    @show_prev = @actual_page >= 1
  end

  def new 
    @task = Task.new
  end

  def show
    @task = Task.find(params[:id])
  end

  def create
    @task = Task.new(task_params)

    if @task.save
      redirect_to action: 'index'
    else
      render :new, status: :unprocessable_entity
    end
  end

  def update
    @task = Task.find(params[:id])

    if @task.update(task_params)
      redirect_to action: 'index'
    else
      render :edit, status: :unprocessable_entity
    end
  end

  def destroy 
    @task = Task.find(params[:id])
    @task.destroy 

    redirect_to action:'index', status: :see_other
  end

  def edit
    @task = Task.find(params[:id])
  end

  private
    def task_params
      params.require(:task).permit(:title, :description, :isActive)
    end 
end
